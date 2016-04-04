using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace WalletApiClient.ApiTypes
{
    /// <summary>
    /// Describes class for response check account action, getting wrapped LoyaltyAccount.
    /// </summary>
    public class CheckAccountsResponse
    {
        /// <summary>
        /// Unique response id as assigned by system.
        /// </summary>
        [JsonProperty("uid")]
        public Guid UniqueId { get; set; }

        /// <summary>
        /// Returns list of memberships containing live balances we retrieved.
        /// </summary>
        [JsonProperty("mbs")]
        public List<ResponseMembershipInfo> Memberships { get; set; }

        /// <summary>
        /// Contains list of errors faced whilst processing request.
        /// E.g. wrong program code, missing segment code etc..
        /// </summary>
        [JsonProperty("err")]
        public List<Error> Errors { get; set; }
    }
}