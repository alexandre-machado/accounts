using Accounts.Web.Controllers;
using Accounts.Web.Models;
using Microsoft.AspNet.Mvc;

namespace MvcSample.Web
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            return View(CreateUser());
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