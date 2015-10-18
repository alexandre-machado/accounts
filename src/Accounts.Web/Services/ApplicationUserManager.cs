using Accounts.Web.Models;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Identity;
using Microsoft.Framework.Logging;
using Microsoft.Framework.OptionsModel;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Threading.Tasks;
using System.Linq;

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

            try
            {
                using (var pc = ConectActiveDirectory())
                {

                    if (pc.ValidateCredentials(user.UserName, password))
                    {
                        var _user = FindByNameAsync(user.UserName);
                        _user.Wait();
                        if (_user.Result == null)
                            CreateAsync(user).Wait();
                        //var _user = await FindByNameAsync(user.UserName);
                        return Task.FromResult(true);
                    }
                    else
                        return Task.FromResult(false);
                }
            }
            catch (System.Exception ex)
            {
                throw new System.Exception("Não foi possível contatar o servidor de autenticação (AD)", ex);
            }
        }

        public override Task<ApplicationUser> FindByNameAsync(string userName)
        {

            return base.FindByNameAsync(userName);
        }

        private PrincipalContext ConectActiveDirectory()
        {
            return new PrincipalContext(ContextType.Domain
                , $"{_appSettings.ActiveDirectoryDomain}"
                , string.Join(",", _appSettings.ActiveDirectoryDomain.Split('.').Select(_ => $"DC={_}")));
        }
    }
}