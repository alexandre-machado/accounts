using Accounts.Web.Controllers;
using Models.ViewModel;
using Xunit;

namespace Accounts.Web.Tests.Controllers
{
    public class AccountControllerTest
    {
        [Fact]
        public void WhenAccountLogin()
        {

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

            var result = controller.Logout();
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