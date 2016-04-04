using Newtonsoft.Json;
using WalletApiClient.Common;

namespace WalletApiClient.ApiTypes
{
    /// <summary>
    /// Contains information about every type of the miles calculated.
    /// </summary>
    public class MilesInfo
    {
        /// <summary>
        /// Type of the miles as defined by our system.
        /// </summary>
        [JsonProperty("at")]
        [JsonConverter(typeof(DefaultJsonEnumConverter))]
        public AccrualType AccrualType { get; set; }

        /// <summary>
        /// Calculated value.
        /// </summary>
        [JsonProperty("val")]
        public double Value { get; set; }
    }
}