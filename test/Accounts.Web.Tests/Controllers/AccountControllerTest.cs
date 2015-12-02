using Accounts.Web.Controllers;
using Accounts.Web.ViewModels.Account;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Accounts.Web.Tests.Controllers
{
    public class AccountControllerTest : BaseControllerTest
    {
        [Fact]
        public void WhenAccountLogin()
        {
            var client = new HttpClient();
            var controller = new AccountController(null, null, null);
            var model = new LoginViewModel();

            var result = controller.Login();
            Assert.NotNull(result);
        }

        [Fact]
        public async Task WhenPatternLoginIsWrong()
        {
            // Act
            var response = await _client.GetAsync("/");
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.Equal("Hello World!",
                responseString);
        }

        [Fact]
        public void WhenAccountLogout()
        {
            var controller = new AccountController(null, null, null);
            var model = new LoginViewModel();

            var result = controller.LogOff();
            Assert.NotNull(result);
        }

        [Fact]
        public void WhenAccessDenied()
        {
            var controller = new AccountController(null, null, null);
            var model = new LoginViewModel();

            var result = controller.AccessDenied();
            Assert.NotNull(result);
        }
    }
}