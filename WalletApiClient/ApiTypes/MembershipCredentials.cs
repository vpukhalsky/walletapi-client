using Newtonsoft.Json;

namespace WalletApiClient.ApiTypes
{
    /// <summary>
    /// One membership parameters required to check an account.
    /// </summary>
    public class MembershipCredentials
    {
        /// <summary>
        /// Gets or sets user's program login.
        /// </summary>
        [JsonProperty("lgn")]
        public string Login { get; set; }

        /// <summary>
        /// Gets or sets user's program password.
        /// </summary>
        [JsonProperty("pwd")]
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets an optional parameter required to check account.
        /// Depends on program. 
        /// </summary>
        [JsonProperty("exp")]
        public string ExtraParam { get; set; }

        /// <summary>
        /// Gets or sets user's program code.
        /// </summary>
        [JsonProperty("pc")]
        public string ProgramCode { get; set; }
    }
}