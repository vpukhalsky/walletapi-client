using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WalletApiClient.Configuration;

namespace WalletApiClient.Tests
{
    /// <summary>
    /// Tests for the ProvidersList method of the WalletApiClient.
    /// </summary>
    [TestClass]
    public class ProvidersListTests
    {
        [TestMethod]
        public void Test_ProvidersReturned()
        {
            var client = new WalletApiClient(new ApiClientConfiguration
            {
                Url = "{ENDPOINT BASE URL}",
                UserName = "{YOUR LOGIN}",
                Password = "{YOUR PASSWORD}",
                Timeout = 180
            });

            var response = client.ProvidersList();

            Assert.IsNotNull(response);
            Assert.IsFalse(response.Errors.Any());
            Assert.IsNotNull(response.Providers);
            Assert.IsTrue(response.Providers.Any());
        }
    }
}
