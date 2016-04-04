using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace WalletApiClient.ApiTypes
{
    /// <summary>
    /// Represents one loyalty membership information.
    /// </summary>
    public class MembershipInfo : BasicMembershipInfo
    {
        [JsonProperty("ctn")]
        public string CurrentTierName { get; set; }

        [JsonProperty("ntn")]
        public string NextTierName { get; set; }

        [JsonProperty("ntc")]
        public int? NextTierCode { get; set; }

        [JsonProperty("nmi")]
        public IEnumerable<MilesInfo> NextStatusBalances { get; set; }

        [JsonProperty("ncd")]
        public IEnumerable<string> NextTierConditions { get; set; }

        [JsonProperty("ntg")]
        public IEnumerable<string> NextTierGril { get; set; }

        [JsonProperty("mnl")]
        public bool IsManual { get; set; }

        [JsonProperty("lvc")]
        public bool IsConnected { get; set; }

        [JsonProperty("upd")]
        public DateTime? LastUpdatedDate { get; set; }
    }
}