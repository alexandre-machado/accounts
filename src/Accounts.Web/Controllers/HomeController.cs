using Accounts.Web.Services;
using Accounts.Web.Services.UserImageProviders;
using Accounts.Web.ViewModels;
using Accounts.Web.ViewModels.Home;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.OptionsModel;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Accounts.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly AppSettings _appSettings;
        private ILogger<HomeController> _logger;
        private ApplicationDbContext _context;
        private IUserImageProvider _userImageProvider;

        public HomeController(
            IOptions<AppSettings> appSettings, ILogger<HomeController> logger, ApplicationDbContext context
            , IUserImageProvider userImageProvider)
        {
            _appSettings = appSettings.Value;
            _logger = logger;
            _context = context;
            _userImageProvider = userImageProvider;
        }

        public IActionResult Index()
        {
            var model = new IndexViewModel
            {
                FullName = User.Identity.Name,
                Login = "alexandrelima",
                Logins = _context.Set<IdentityUserLogin<string>>()
                    .Select(_ => new UserLoginViewModel { }).ToList()
            };
            return View(model);
        }

        [AllowAnonymous]
        public IActionResult About()
        {
            return View();
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 3600)]
        [Route("profile-image/{login}/s:{size}")]
        [Route("profile-image/{login}")]
        public async Task<IActionResult> ProfileImage(string login, int size = 100)
        {
            using (var client = new WebClient())
            {
                var uri = _userImageProvider.UserImageUrl(User.Identity, HttpContext.Request.IsHttps ? "https" : "http", size);

                try
                {
                    var data = await client.DownloadDataTaskAsync(uri);
                    return File(data, "image/jpeg");
                }
                catch
                {
                    _logger.LogDebug($"erro no carregamento da imagem. url: '{uri}'");
                    return File("~/img/default-user.png", "image/png");
                }
            }
        }
    }
}