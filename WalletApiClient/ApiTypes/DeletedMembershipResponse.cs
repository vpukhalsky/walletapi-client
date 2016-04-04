using System;
using Newtonsoft.Json;

namespace WalletApiClient.ApiTypes
{
    public class DeletedMembershipResponse
    {
        /// <summary>
        /// Unique response id as assigned by system.
        /// </summary>
        [JsonProperty("uid")]
        public Guid UniqueId { get; set; }
    }
}