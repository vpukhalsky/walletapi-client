using Newtonsoft.Json;

namespace WalletApiClient.ApiTypes
{
    /// <summary>
    /// Represents error information
    /// </summary>
    public class Error
    {
        /// <summary>
        /// Code of the error if any.
        /// </summary>
        [JsonProperty("ec")]
        public string Code { get; set; }

        /// <summary>
        /// Description of the error.
        /// </summary>
        [JsonProperty("em")]
        public string Message { get; set; }
    }
}