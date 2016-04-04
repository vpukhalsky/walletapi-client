using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace WalletApiClient.ApiTypes
{
    /// <summary>
    /// Describes class for ProvidersList response
    /// </summary>
    public class ProvidersListResponse
    {
        /// <summary>
        /// Unique response id as assigned by system.
        /// </summary>
        [JsonProperty("uid")]
        public Guid UniqueId { get; set; }

        /// <summary>
        /// Returns total number of providers found
        /// </summary>
        [JsonProperty("tpc")]
        public int ProvidersCount { get; set; }

        /// <summary>
        /// Returns list of memberships containing live balances we retrieved.
        /// </summary>
        [JsonProperty("pvd")]
        public List<ProviderInfo> Providers { get; set; }

        /// <summary>
        /// Contains list of errors faced whilst processing request.
        /// E.g. wrong program code, missing segment code etc..
        /// </summary>
        [JsonProperty("err")]
        public List<Error> Errors { get; set; }
    }
}