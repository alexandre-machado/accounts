using Accounts.Web.Models;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Identity;
using Microsoft.Framework.Logging;
using Microsoft.Framework.OptionsModel;
using System.DirectoryServices.AccountManagement;
using System.Threading.Tasks;

namespace Accounts.Web.Services
{
    public class ApplicationSignInManager : SignInManager<ApplicationUser>
    {
        private readonly AppSettings _appSettings;

        public ApplicationSignInManager(ApplicationUserManager userManager
            , IHttpContextAccessor contextAccessor
            , IUserClaimsPrincipalFactory<ApplicationUser> claimsFactory
            , IOptions<IdentityOptions> optionsAccessor
            , ILogger<SignInManager<ApplicationUser>> logger
            , IOptions<AppSettings> appSettings)
            : base(userManager, contextAccessor, claimsFactory, optionsAccessor, logger)
        {
            _appSettings = appSettings.Options;
        }

        public override Task<SignInResult> PasswordSignInAsync(string userName, string password, bool isPersistent, bool lockoutOnFailure)
        {
            return base.PasswordSignInAsync(userName, password, isPersistent, lockoutOnFailure);
        }
    }
}
