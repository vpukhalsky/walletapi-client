using System.Collections.Generic;
using Newtonsoft.Json;

namespace WalletApiClient.ApiTypes
{
    /// <summary>
    /// Allows memberships manual input into wallet.
    /// </summary>
    public class AccountsManualInputRequest
    {
        /// <summary>
        /// Gets or sets user's memberships list to be checked.
        /// </summary>
        [JsonProperty("mbs")]
        public List<BasicMembershipInfo> Memberships { get; set; }

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