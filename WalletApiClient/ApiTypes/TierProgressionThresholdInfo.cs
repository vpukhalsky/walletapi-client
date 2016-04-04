using Newtonsoft.Json;
using WalletApiClient.Common;

namespace WalletApiClient.ApiTypes
{
    public class TierProgressionThresholdInfo
    {
        /// <summary>
        /// The type of the miles as known by our system.
        /// Should be used to reference accrual type from MilesInfo type.
        /// </summary>
        [JsonProperty("at")]
        [JsonConverter(typeof(DefaultJsonEnumConverter))]
        public AccrualType AccrualType { get; set; }

        /// <summary>
        /// Name of the program's accrual metric
        /// </summary>
        [JsonProperty("atn")]
        public string MetricName { get; set; }

        /// <summary>
        /// Expected to be the bottom threshold of the level.
        /// </summary>
        [JsonProperty("val")]
        public double Value { get; set; }
    }
}