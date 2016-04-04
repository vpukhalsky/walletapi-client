using System.Collections.Generic;
using Newtonsoft.Json;

namespace WalletApiClient.ApiTypes
{
    public class TiersLevelsInfo
    {
        /// <summary>
        /// Some legend for tiers levels
        /// </summary>
        [JsonProperty("lgn")]
        public string Legend { get; set; }

        /// <summary>
        /// Contains geographical limitations of the tier
        /// </summary>
        [JsonProperty("geo")]
        public List<string> Gril { get; set; }

        /// <summary>
        /// Contains information about how many bonuses should be earned to progress to the tier
        /// </summary>
        [JsonProperty("thr")]
        public List<TierProgressionThresholdInfo> Thresholds { get; set; }
    }
}