using System.Collections.Generic;
using Newtonsoft.Json;

namespace WalletApiClient.ApiTypes
{
    /// <summary>
    /// Describes incoming parameters for the CheckAccounts WalletAPI method.
    /// </summary>
    public class CheckAccountsRequest
    {
        /// <summary>
        /// Gets or sets user's memberships list to be checked.
        /// </summary>
        [JsonProperty("mbs")]
        public List<MembershipCredentials> Memberships { get; set; }

        /// <summary>
        /// Gets or sets value that identifies user at client's side
        /// </summary>
        [JsonProperty("uid")]
        public string ClientUserId { get; set; }

        /// <summary>
        /// Optional parameter to store user's country of residence code
        /// </summary>
        [JsonProperty("ucc")]
        public string UserCountryCode { get; set; }
    }
}
