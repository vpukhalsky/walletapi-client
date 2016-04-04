namespace WalletApiClient.Configuration
{
    /// <summary>
    /// Provides access to the service client essential configuration.
    /// </summary>
    public interface IBaseApiClientConfiguration
    {
        /// <summary>
        /// Requested Url
        /// </summary>
        string Url { get; }

        /// <summary>
        /// User name (autorization)
        /// </summary>
        string UserName { get; }

        /// <summary>
        /// Password of the user (autorization)
        /// </summary>
        string Password { get; }

        /// <summary>
        /// Returns timeout in seconds
        /// </summary>
        int Timeout { get; }
    }
}
