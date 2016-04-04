using System.Collections.Generic;
using Newtonsoft.Json;

namespace WalletApiClient.ApiTypes
{
    public class ProviderInfo
    {
        /// <summary>
        /// Returns original provider code.
        /// </summary>
        [JsonProperty("pcd")]
        public string Code { get; set; }

        /// <summary>
        /// Returns title of the login field.
        /// </summary>
        [JsonProperty("lgn")]
        public string Login { get; set; }

        /// <summary>
        /// Returns title of the password field.
        /// </summary>
        [JsonProperty("pwd")]
        public string Password { get; set; }

        /// <summary>
        /// Returns title of the extra parameter required for the login.
        /// </summary>
        [JsonProperty("ext")]
        public string ExtraParameter { get; set; }

        /// <summary>
        /// Returns list of options for the 3rd parameter if any specified.
        /// </summary>
        [JsonProperty("opt")]
        public ProviderOptionInfo[] Options { get; set; }

        /// <summary>
        /// Returns list of available tiers and its qualification levels
        /// </summary>
        [JsonProperty("trs")]
        public List<TierInfo> AvailableTiers { get; set; }
    }
}