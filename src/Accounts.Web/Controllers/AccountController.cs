using Microsoft.AspNet.Authentication.Cookies;
using Microsoft.AspNet.Mvc;
using System.Collections.Generic;
using System.Security.Claims;

namespace Accounts.Web.Controllers
{
    public class AccountController : BaseController
    {
        [AllowAnonymous]
        public IActionResult Login()
        {
            //var claims = new List<Claim> { new Claim(ClaimTypes.Name, model.Username) };
            //Context.Response.SignIn(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(new ClaimsIdentity(claims, "Cookies")));
            return View();
        }

        public IActionResult Logout()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
