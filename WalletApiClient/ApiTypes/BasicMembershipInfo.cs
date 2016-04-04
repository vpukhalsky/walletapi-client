using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace WalletApiClient.ApiTypes
{
    /// <summary>
    /// Represents very basic information about membership.
    /// Can be manually set by user without harming security.
    /// </summary>
    public class BasicMembershipInfo
    {
        [JsonProperty("pc")]
        public string ProgramCode { get; set; }

        [JsonProperty("mnu")]
        public string MembershipNumber { get; set; }

        [JsonProperty("mna")]
        public string MemberName { get; set; }

        [JsonProperty("ctc")]
        public int? CurrentTierCode { get; set; }

        [JsonProperty("cmi")]
        public List<MilesInfo> CurrentBalances { get; set; }

        [JsonProperty("ini")]
        public bool? IsInitialized { get; set; }

        [JsonProperty("exd")]
        public DateTime? ExpirationDate { get; set; }
    }
}