using System.Collections.Generic;
using Newtonsoft.Json;

namespace WalletApiClient.ApiTypes
{
    public class ResponseMembershipInfo : MembershipInfo
    {
        /// <summary>
        /// Contains list of errors faced whilst processing request.
        /// E.g. wrong program code, missing segment code etc..
        /// </summary>
        [JsonProperty("mer")]
        public List<Error> Errors { get; set; }
    }
}