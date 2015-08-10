using Microsoft.AspNet.Mvc;

namespace Accounts.Web.Controllers
{
    public class AccountController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
