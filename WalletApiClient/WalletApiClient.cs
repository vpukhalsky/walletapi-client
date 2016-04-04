using System;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Reflection;
using System.Text;
using log4net;
using WalletApiClient.ApiTypes;
using WalletApiClient.Common;
using WalletApiClient.Configuration;

namespace WalletApiClient
{
    /// <summary>
    /// Client for WalletAPI
    /// </summary>
    public class WalletApiClient
    {
        #region Constants

        private const string METHOD_URL_CHECK = "/api/checkaccounts/";
        private const string METHOD_URL_MANUAL = "/api/accountsmanual/";
        private const string METHOD_URL_MEMBERSHIPS = "/api/memberships/";
        private const string METHOD_URL_PROVIDERS = "/api/providers/";

        #endregion

        #region Fields

        private static readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private static readonly JsonSerializer _serializer;
        private readonly IBaseApiClientConfiguration _apiClientConfiguration;

        #endregion

        #region .ctor

        static WalletApiClient()
        {
            _serializer = new JsonSerializer();
        }

        public WalletApiClient(IBaseApiClientConfiguration configuration)
        {
            if(configuration == null) throw new ArgumentNullException("configuration");

            _apiClientConfiguration = configuration;
        }

        #endregion

        #region Proxy methods to the WalletAPI.

        /// <summary>
        /// Invokes the "CheckAccounts" method of the WalletAPI 
        /// used to scrape FFP accounts data for the specified credentials
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public CheckAccountsResponse CheckAccounts(CheckAccountsRequest request)
        {
            var targetUrl = BuildTargetUrl(METHOD_URL_CHECK);

            var response = SendRequest<ActionResult<CheckAccountsResponse>, CheckAccountsRequest>(
                targetUrl,
                HttpVerb.POST,
                request);

            return response.Value;
        }

        /// <summary>
        /// Invokes ProviersList method.
        /// Returns list of all supported programs with their configuration.
        /// </summary>
        /// <returns></returns>
        public ProvidersListResponse ProvidersList()
        {
            var targetUrl = BuildTargetUrl(METHOD_URL_PROVIDERS);

            var response = SendRequest<ActionResult<ProvidersListResponse>, object>(
                targetUrl,
                HttpVerb.GET);

            return response.Value;
        }

        /// <summary>
        /// Invokes AccountsManualInput method.
        /// Returns memberhips information decorated with tiers (current and next) specific information.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public CheckAccountsResponse ManualInput(AccountsManualInputRequest request)
        {
            var targetUrl = BuildTargetUrl(METHOD_URL_MANUAL);

            var response = SendRequest<ActionResult<CheckAccountsResponse>, AccountsManualInputRequest>(
                targetUrl,
                HttpVerb.POST,
                request);

            return response.Value;
        }

        /// <summary>
        /// Invokes Memberhips method.
        /// Returns list of memberships connected to the given ClientUserId.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public CheckAccountsResponse Memberships(MembershipsRequest request)
        {
            var targetUrl = BuildTargetUrl(METHOD_URL_MEMBERSHIPS);

            var response = SendRequest<ActionResult<CheckAccountsResponse>, MembershipsRequest>(
                targetUrl,
                HttpVerb.POST,
                request);

            return response.Value;
        }

        /// <summary>
        /// Removes membership associated with the given ClientUserId.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public DeletedMembershipResponse Memberships(DeleteMembershipRequest request)
        {
            var targetUrl = BuildTargetUrl(METHOD_URL_MEMBERSHIPS);

            var response = SendRequest<ActionResult<DeletedMembershipResponse>, DeleteMembershipRequest>(
                targetUrl,
                HttpVerb.DELETE,
                request);

            return response.Value;
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Sends web-api request to the target url and deserializes the response to the specified type.
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <typeparam name="TData"></typeparam>
        /// <returns></returns>
        private TResult SendRequest<TResult, TData>(string url, string httpVerb, TData data = null)
            where TResult : class
            where TData : class
        {
            ServicePointManager.ServerCertificateValidationCallback += delegate { return true; };

            _logger.InfoFormat("Sending request to the '{0}'.", _apiClientConfiguration.Url);

            var bytes = Encoding.UTF8.GetBytes(
                string.Format("{0}:{1}",
                    _apiClientConfiguration.UserName,
                    _apiClientConfiguration.Password));

            var base64AutorizationData = Convert.ToBase64String(bytes);

            var webRequest = WebRequest.Create(url);
            webRequest.Method = httpVerb;
            webRequest.ContentType = "application/json";
            webRequest.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip");
            webRequest.Headers.Add(HttpRequestHeader.ContentEncoding, "utf-8");
            webRequest.Headers.Add(HttpRequestHeader.Authorization, string.Format("Basic {0}", base64AutorizationData));
            webRequest.Timeout = _apiClientConfiguration.Timeout * 1000;

            if (data != null
                && (httpVerb.Equals(HttpVerb.POST, StringComparison.OrdinalIgnoreCase)
                || httpVerb.Equals(HttpVerb.DELETE, StringComparison.OrdinalIgnoreCase)))
            {
                var source = _serializer.Serialize(data);

                _logger.DebugFormat("Request for WalletAPI: '{0}'", source);

                byte[] requestData = Encoding.UTF8.GetBytes(source);

                webRequest.ContentLength = requestData.Length;

                using (var stream = webRequest.GetRequestStream())
                {
                    stream.Write(requestData, 0, requestData.Length);
                }
            }

            using (var webResponse = webRequest.GetResponse())
            {
                string contentEncoding = null;

                _logger.InfoFormat("Response length: {0}", webResponse.ContentLength);

                if (webResponse.Headers.Get("Content-Encoding") != null)
                {
                    contentEncoding = webResponse.Headers.Get("Content-Encoding");

                    _logger.InfoFormat("Api response encoded: {0}", contentEncoding);
                }

                var deserializedData = DeserializeResponse<TResult>(webResponse.GetResponseStream(), contentEncoding);

                return deserializedData;
            }
        }

        /// <summary>
        /// Deserializes response to the target type.
        /// </summary>
        /// <param name="searchResponseStream"></param>
        /// <param name="contentEncoding"></param>
        /// <returns></returns>
        private T DeserializeResponse<T>(Stream searchResponseStream, string contentEncoding = null)
        {
            var responseContent = GetResponseContentBasedOnResponseType(searchResponseStream, contentEncoding);

            return _serializer.Deserialize<T>(responseContent);
        }


        /// <summary>
        /// As we could receive gzipped content need to add extra logic to handle that.
        /// </summary>
        /// <param name="response"></param>
        /// <param name="contentEncoding"></param>
        /// <returns></returns>
        private string GetResponseContentBasedOnResponseType(Stream response, string contentEncoding)
        {
            var contentPacked = false;

            StreamReader reader;

            //The following is to check if the server sending the response supports Gzip
            if (!string.IsNullOrEmpty(contentEncoding) && contentEncoding.ToLower() == "gzip")
            {
                reader = new StreamReader(new GZipStream(response, CompressionMode.Decompress));

                contentPacked = true;
            }
            else
            {
                reader = new StreamReader(response);
            }

            var responseText = reader.ReadToEnd();

            if (contentPacked)
            {
                _logger.InfoFormat("Decoded response length: {0} bytes", responseText.Length);
            }

            return responseText;
        }

        /// <summary>
        /// Builds target url from the specified method url and configured endpoint url
        /// </summary>
        /// <param name="methodUrl"></param>
        /// <returns></returns>
        protected string BuildTargetUrl(string methodUrl)
        {
            return _apiClientConfiguration.Url.TrimEnd(' ', '/') + methodUrl;
        }

        #endregion
    }
}