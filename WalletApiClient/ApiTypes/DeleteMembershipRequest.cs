using Newtonsoft.Json;

namespace WalletApiClient.ApiTypes
{
    /// <summary>
    /// Describes incoming parameters for the Delete Memberships WalletAPI method.
    /// </summary>
    public class DeleteMembershipRequest
    {
        /// <summary>
        /// Gets or sets value that identifies user at client's side
        /// </summary>
        [JsonProperty("uid")]
        public string ClientUserId { get; set; }

        /// <summary>
        /// Gets or sets value that identifies which membership should be removed
        /// </summary>
        [JsonProperty("pc")]
        public string ProgramCode { get; set; }
    }
}