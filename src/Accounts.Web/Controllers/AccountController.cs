using Microsoft.AspNet.Mvc;

namespace Accounts.Web.Controllers
{
    [AllowAnonymous]
    public class AccountController : BaseController
    {
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Logout()
        {
            return View();
        }
    }
}
