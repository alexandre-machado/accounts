using Accounts.Web.Models;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Identity;
using Microsoft.Framework.Logging;
using Microsoft.Framework.OptionsModel;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Threading.Tasks;

namespace Accounts.Web.Services
{
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        private readonly AppSettings _appSettings;

        public ApplicationUserManager(
            IUserStore<ApplicationUser> store
            , IOptions<IdentityOptions> optionsAccessor
            , IPasswordHasher<ApplicationUser> passwordHasher
            , IEnumerable<IUserValidator<ApplicationUser>> userValidators
            , IEnumerable<IPasswordValidator<ApplicationUser>> passwordValidators
            , ILookupNormalizer keyNormalizer
            , IdentityErrorDescriber errors
            , IEnumerable<IUserTokenProvider<ApplicationUser>> tokenProviders
            , ILogger<UserManager<ApplicationUser>> logger
            , IHttpContextAccessor contextAccessor
            , IOptions<AppSettings> appSettings)
            : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer
                  , errors, tokenProviders, logger, contextAccessor)

        {
            _appSettings = appSettings.Options;
        }

        public override Task<bool> CheckPasswordAsync(ApplicationUser user, string password)
        {
            if (string.IsNullOrEmpty(_appSettings.ActiveDirectoryDomain))
                return base.CheckPasswordAsync(user, password);
               
            var pc = new PrincipalContext(ContextType.Domain
                , $"{_appSettings.ActiveDirectoryDomain}", $"DC={_appSettings.ActiveDirectoryDomain}");

            if (pc.ValidateCredentials(user.UserName, password))
                return Task.FromResult(true);
            else
                return Task.FromResult(false);
        }
    }
}

