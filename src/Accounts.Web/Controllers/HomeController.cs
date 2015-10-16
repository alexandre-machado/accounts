using Accounts.Web.Models;
using Accounts.Web.Models.ViewModel;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;
using Microsoft.Framework.OptionsModel;
using System.Net;
using System.Threading.Tasks;

namespace Accounts.Web.Controllers
{
    //[Authorize]
    public class HomeController : BaseController
    {
        private readonly AppSettings _appSettings;

        public HomeController(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Options;
        }

        public IActionResult Index()
        {
            var model = new IndexViewModel
            {
                FullName = "Alexandre Machado",
                Login = "alexandrelima",
                Domain = "cwinet"
            };
            return View(model);
        }

        [AllowAnonymous]
        public IActionResult About()
        {
            return View();
        }

        [Route("profile-image/{domain}/{login}")]
        [AllowAnonymous]
        [ResponseCache(Duration = 3600)]
        public async Task<IActionResult> ProfileImage(string domain, string login)
        {
            using (var client = new WebClient())
            {
                var uri = string.Format(_appSettings.ExternalImageUrl, login, domain);
                var data = await client.DownloadDataTaskAsync(uri);
                return File(data, "image/jpeg");
            }
        }
    }
}