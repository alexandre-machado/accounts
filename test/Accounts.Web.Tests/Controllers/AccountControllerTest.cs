using Accounts.Web.Controllers;
using Accounts.Web.ViewModels.Account;
using Microsoft.AspNet.TestHost;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Accounts.Web.Tests.Controllers
{
    public class AccountControllerTest : BaseControllerTest
    {
        [Fact]
        public async void WhenAccountLogout()
        {
            // Act
            var response = await _client.GetAsync("/Account/LogOff");

            // Assert
            Assert.True(response.StatusCode == System.Net.HttpStatusCode.Found);
            Assert.Equal(response.Headers.Location.AbsolutePath, "/Account/Login");
        }


        [Fact]
        public async void WhenAccountLogin()
        {
            // Act
            var content = new LoginViewModel { };
            var response = await _client.PostAsJsonAsync("/Account/Login", content);
            response.EnsureSuccessStatusCode();

            // Assert
            Assert.True(response.StatusCode == System.Net.HttpStatusCode.Found);
        }
    }
}