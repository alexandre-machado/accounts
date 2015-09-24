using Accounts.Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Mvc;
using Models;
using System.Threading.Tasks;

namespace Accounts.Web.Controllers
{
    public class AccountController : BaseController
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            //var claims = new List<Claim> { new Claim(ClaimTypes.Name, model.Username) };
            //Context.Response.SignIn(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(new ClaimsIdentity(claims, "Cookies")));
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            string returnUrl = null;
            ViewData["ReturnUrl"] = returnUrl;

            if (!ModelState.IsValid)
            {
                return new ObjectResult(new { message = "campos obrigatórios", status = "error" });
            }
            
            var result = await _signInManager.PasswordSignInAsync(model.Login, model.Password, model.RememberMe, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                //return RedirectToLocal(returnUrl);
                return new ObjectResult(new { returnUrl = returnUrl });
            }
            if (result.IsLockedOut)
            {
                return new ObjectResult(new { returnUrl = "Lockout" });
            }
            else
            {
                return new ObjectResult(new { message = "login inválido", status = "error" });
            }
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

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }
    }
}
