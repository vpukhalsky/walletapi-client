using System.Collections.Generic;
using Newtonsoft.Json;
using WalletApiClient.Common;

namespace WalletApiClient.ApiTypes
{
    public class TierInfo
    {
        /// <summary>
        /// The tier as known by our system.
        /// Should be used to reference UserTier from ProgramInfo.UserTier.
        /// </summary>
        [JsonProperty("ta")]
        [JsonConverter(typeof(DefaultJsonEnumConverter))]
        public TierAlias Alias { get; set; }

        /// <summary>
        /// Tier's unique name
        /// </summary>
        [JsonProperty("tn")]
        public string Name { get; set; }

        /// <summary>
        /// Tiers levels configuration for status qualification.
        /// </summary>
        [JsonProperty("ql")]
        public List<TiersLevelsInfo> QualificationLevels { get; set; }

        /// <summary>
        /// Tiers levels configuration for status renewal if differs from Qualification.
        /// </summary>
        [JsonProperty("rl")]
        public List<TiersLevelsInfo> RenewalLevels { get; set; }
    }
}