using Accounts.Web.Controllers;
using Accounts.Web.Models;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;

namespace MvcSample.Web
{
    public class HomeController : BaseController
    {
        [Authorize]
        public IActionResult Index()
        {
            return View(CreateUser());
        }

        [AllowAnonymous]
        public IActionResult About()
        {
            return View();
        }

        public User CreateUser()
        {
            User user = new User()
            {
                Name = "My name",
                Address = "My address"
            };

            return user;
        }
    }
}