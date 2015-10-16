using Accounts.Web.Controllers;
using Xunit;

namespace Accounts.Web.Tests.Controllers
{
    public class HomeControllerTest
    {
        [Fact]
        public void WhenCreateUser_ResultShouldNotBeNull()
        {
            var controller = new HomeController(null);
            var result = controller.Index();
            Assert.NotNull(result);
        }
    }
}