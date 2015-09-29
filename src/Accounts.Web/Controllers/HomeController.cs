using Accounts.Web.Models;
using Accounts.Web.Models.ViewModel;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;
using Microsoft.Framework.OptionsModel;

namespace Accounts.Web.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController()
        {
        }

        [Authorize]
        public IActionResult Index()
        {
            var model = new IndexViewModel { FullName = "Alexandre Machado" };
            return View(model);
        }

        [AllowAnonymous]
        public IActionResult About()
        {
            return View();
        }
    }
}