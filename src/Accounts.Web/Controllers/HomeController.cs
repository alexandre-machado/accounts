using Accounts.Web.Services.UserImageProviders;
using Accounts.Web.ViewModels;
using Microsoft.AspNet.Mvc;
using Microsoft.Framework.Logging;
using Microsoft.Framework.OptionsModel;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Accounts.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly AppSettings _appSettings;
        private ILogger<HomeController> _logger;

        public HomeController(IOptions<AppSettings> appSettings, ILogger<HomeController> logger)
        {
            _appSettings = appSettings.Value;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var model = new IndexViewModel
            {
                FullName = User.Identity.Name,
                Login = "alexandrelima",
            };
            return View(model);
        }

        [AllowAnonymous]
        public IActionResult About()
        {
            return View();
        }

        [Route("profile-image/{login}")]
        [AllowAnonymous]
        [ResponseCache(Duration = 3600)]
        public async Task<IActionResult> ProfileImage(string login)
        {
            using (var client = new WebClient())
            {
                var imageProvider = (IUserImageProvider)this.HttpContext.RequestServices
                    .GetService(Type.GetType("Accounts.Web.Services.UserImageProviders.SharePointProvider"));

                var uri = imageProvider.UserImageUrl(User.Identity);

                try
                {
                    var data = await client.DownloadDataTaskAsync(uri);
                    return File(data, "image/jpeg");
                }
                catch (AggregateException ex)
                {
                    _logger.LogDebug("erro no carregamento da imagem");
                    return new BadRequestObjectResult(ex.Message);
                }
            }
        }
    }
}