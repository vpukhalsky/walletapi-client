using Newtonsoft.Json;

namespace WalletApiClient.ApiTypes
{
    /// <summary>
    /// Describes incoming parameters for the Memberships WalletAPI method.
    /// </summary>
    public class MembershipsRequest
    {
        /// <summary>
        /// Gets or sets value that identifies user at client's side
        /// </summary>
        [JsonProperty("uid")]
        public string ClientUserId { get; set; }
    }
}