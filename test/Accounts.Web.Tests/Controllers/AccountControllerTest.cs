using Accounts.Web.Controllers;
using Microsoft.Framework.Configuration;
using Models.ViewModel;
using System.Net.Http;
using Xunit;

namespace Accounts.Web.Tests.Controllers
{
    public class AccountControllerTest
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