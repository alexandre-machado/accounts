using Accounts.Web.Controllers;
using Models;
using Xunit;

namespace Accounts.Web.Tests.Controllers
{
    public class AccountControllerTest
    {
        [Fact]
        public void WhenAccountLogout()
        {
            var controller = new AccountController(null, null);
            var model = new LoginViewModel();

            var result = controller.Logout();
            Assert.NotNull(result);
        }
    }
}