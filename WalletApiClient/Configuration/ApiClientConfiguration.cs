namespace WalletApiClient.Configuration
{
    /// <summary>
    /// Configuration of the test framework (test rule runner)
    /// </summary>
    public class ApiClientConfiguration : IBaseApiClientConfiguration
    {
        /// <summary>
        /// Requested Url
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// User name (autorization)
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Password of the user (autorization)
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Returns timeout in seconds
        /// </summary>
        public int Timeout { get; set; }
    }
}