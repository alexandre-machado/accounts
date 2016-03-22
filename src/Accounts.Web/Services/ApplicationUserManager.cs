using Accounts.Web.Models;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.OptionsModel;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace Accounts.Web.Services
{
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        private readonly AppSettings _appSettings;
        private IUserStore<ApplicationUser> _store;
        private IHttpContextAccessor _contextAccessor;

        public ApplicationUserManager(
            IUserStore<ApplicationUser> store
            , IOptions<IdentityOptions> optionsAccessor
            , IPasswordHasher<ApplicationUser> passwordHasher
            , IEnumerable<IUserValidator<ApplicationUser>> userValidators
            , IEnumerable<IPasswordValidator<ApplicationUser>> passwordValidators
            , ILookupNormalizer keyNormalizer
            , IdentityErrorDescriber errors
            , IServiceProvider services
            , ILogger<UserManager<ApplicationUser>> logger
            , IHttpContextAccessor contextAccessor
            , IOptions<AppSettings> appSettings)
            : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer
                  , errors, services, logger, contextAccessor)

        {
            _appSettings = appSettings.Value;
            _store = store;
            _contextAccessor = contextAccessor;
        }

        public override Task<bool> CheckPasswordAsync(ApplicationUser user, string password)
        {
            if (string.IsNullOrEmpty(_appSettings.ActiveDirectoryDomain))
                return base.CheckPasswordAsync(user, password);

            try
            {
                using (var AD = ActiveDirectory())
                {
                    if (AD.ValidateCredentials(user.UserName, password))
                    {
                        _contextAccessor.HttpContext.Session.SetString("activeDirectory.userName", user.UserName);
                        _contextAccessor.HttpContext.Session.SetString("activeDirectory.password", password);
                        return Task.FromResult(true);
                    }
                    return Task.FromResult(false);

                }
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível contatar o servidor de autenticação (AD)", ex);
            }
        }

        public override Task<ApplicationUser> FindByLoginAsync(string loginProvider, string providerKey)
        {
            return base.FindByLoginAsync(loginProvider, providerKey);
        }

        public override Task<ApplicationUser> FindByEmailAsync(string email)
        {
            return base.FindByEmailAsync(email);
        }

        public override Task<ApplicationUser> FindByNameAsync(string userName)
        {
            return base.FindByNameAsync(userName);
        }

        public ApplicationUser CurrentUser
        {
            get
            {
                var task = FindByNameAsync(_contextAccessor.HttpContext.Session.GetString("activeDirectory.userName"));
                task.Wait();
                return task.Result;
            }
        }

        private PrincipalContext ActiveDirectory()
        {
            return new PrincipalContext(ContextType.Domain
                , $"{_appSettings.ActiveDirectoryDomain}"
                , string.Join(",", _appSettings.ActiveDirectoryDomain.Split('.').Select(_ => $"DC={_}")));
        }
    }
}