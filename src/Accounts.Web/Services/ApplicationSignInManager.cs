using Accounts.Web.Models;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.OptionsModel;
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
            _appSettings = appSettings.Value;
        }

        public override Task<SignInResult> PasswordSignInAsync(string userName, string password, bool isPersistent, bool lockoutOnFailure)
        {
            return base.PasswordSignInAsync(userName, password, isPersistent, lockoutOnFailure);
        }

        public override Task<SignInResult> PasswordSignInAsync(ApplicationUser user, string password, bool isPersistent, bool lockoutOnFailure)
        {
            return base.PasswordSignInAsync(user, password, isPersistent, lockoutOnFailure);
        }
    }
}
