using Accounts.Web.Controllers;
using Xunit;

namespace Accounts.Web.Tests.Controllers
{
    public class HomeControllerTest : BaseControllerTest
    {
        [Fact]
        public async void WhenHomeShouldBeRedirect()
        {
            // Act
            var response = await _client.GetAsync("/");

            // Assert
            Assert.True(response.StatusCode == System.Net.HttpStatusCode.Found);
            Assert.Equal(response.Headers.Location.AbsolutePath, "/Account/Login");
        }
    }
}