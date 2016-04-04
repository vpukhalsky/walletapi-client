using Newtonsoft.Json;

namespace WalletApiClient.ApiTypes
{
    public class ProviderOptionInfo
    {
        [JsonProperty("cod")]
        public string Code { get; set; }

        [JsonProperty("val")]
        public string Value { get; set; }
    }
}