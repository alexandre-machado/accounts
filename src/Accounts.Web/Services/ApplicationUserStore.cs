using Accounts.Web.Models;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Identity;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.OptionsModel;
using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace Accounts.Web.Services
{
    public class ApplicationUserStore<TUser> :
        //IUserLoginStore<TUser>,
        //IUserRoleStore<TUser>,
        //IUserClaimStore<TUser>,
        IUserPasswordStore<TUser>,
        //IUserSecurityStampStore<TUser>,
        IUserEmailStore<TUser>,
        //IUserLockoutStore<TUser>,
        IUserPhoneNumberStore<TUser>,
        IQueryableUserStore<TUser>
        //IUserTwoFactorStore<TUser>
        where TUser : ApplicationUser
    {
        private bool disposedValue = false; // To detect redundant calls
        private IMemoryCache _cache;
        private AppSettings _appSettings;
        private IHttpContextAccessor _contextAccessor;

        public ApplicationUserStore(
            IMemoryCache cache
            , IHttpContextAccessor contextAccessor
            , IOptions<AppSettings> appSettings)
        {
            _cache = cache;
            _appSettings = appSettings.Value;
            _contextAccessor = contextAccessor;
        }

        IQueryable<TUser> IQueryableUserStore<TUser>.Users
        {
            get
            {
                using (var AD = ActiveDirectory())
                using (var userPrincipal = new UserPrincipal(AD))
                using (var search = new PrincipalSearcher(userPrincipal))
                {
                    var query = search.FindAll()
                        .Cast<UserPrincipal>()
                        .Select(s =>
                            (TUser)new ApplicationUser(s)).ToArray();

                    return query.AsQueryable<TUser>();
                }
            }
        }

        public IQueryable<TUser> AllUsers { get { return ((IQueryableUserStore<TUser>)this).Users; } }

        public PrincipalContext ActiveDirectory()
        {
            return new PrincipalContext(
                ContextType.Domain
                , _appSettings.ActiveDirectoryDomain
                , _ADUserName
                , _ADPassword);
        }

        Task<IdentityResult> IUserStore<TUser>.CreateAsync(TUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<IdentityResult> IUserStore<TUser>.DeleteAsync(TUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<TUser> IUserEmailStore<TUser>.FindByEmailAsync(string normalizedEmail, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<TUser> IUserStore<TUser>.FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<TUser> IUserStore<TUser>.FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            using (var ad = ActiveDirectory())
            using (var userPrincipal = new UserPrincipal(ad))
            {
                userPrincipal.SamAccountName = normalizedUserName;

                using (var search = new PrincipalSearcher(userPrincipal))
                using (var result = (UserPrincipal)search.FindOne())
                {
                    search.Dispose();

                    var user = new ApplicationUser(result);

                    return Task<TUser>.FromResult((TUser)user);
                }
            }
        }

        Task<string> IUserEmailStore<TUser>.GetEmailAsync(TUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<bool> IUserEmailStore<TUser>.GetEmailConfirmedAsync(TUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<string> IUserEmailStore<TUser>.GetNormalizedEmailAsync(TUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<string> IUserStore<TUser>.GetNormalizedUserNameAsync(TUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<string> IUserPasswordStore<TUser>.GetPasswordHashAsync(TUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<string> IUserPhoneNumberStore<TUser>.GetPhoneNumberAsync(TUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<bool> IUserPhoneNumberStore<TUser>.GetPhoneNumberConfirmedAsync(TUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<string> IUserStore<TUser>.GetUserIdAsync(TUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Id);
        }

        Task<string> IUserStore<TUser>.GetUserNameAsync(TUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.UserName);
        }

        Task<bool> IUserPasswordStore<TUser>.HasPasswordAsync(TUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task IUserEmailStore<TUser>.SetEmailAsync(TUser user, string email, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task IUserEmailStore<TUser>.SetEmailConfirmedAsync(TUser user, bool confirmed, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task IUserEmailStore<TUser>.SetNormalizedEmailAsync(TUser user, string normalizedEmail, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task IUserStore<TUser>.SetNormalizedUserNameAsync(TUser user, string normalizedName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task IUserPasswordStore<TUser>.SetPasswordHashAsync(TUser user, string passwordHash, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task IUserPhoneNumberStore<TUser>.SetPhoneNumberAsync(TUser user, string phoneNumber, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task IUserPhoneNumberStore<TUser>.SetPhoneNumberConfirmedAsync(TUser user, bool confirmed, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task IUserStore<TUser>.SetUserNameAsync(TUser user, string userName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<IdentityResult> IUserStore<TUser>.UpdateAsync(TUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public string _ADPassword
        {
            get
            {
                return _contextAccessor.HttpContext.Session.GetString("activedirectory.password");
            }
            set
            {
                _contextAccessor.HttpContext.Session.SetString("activedirectory.password", value);
            }
        }

        public string _ADUserName
        {
            get
            {
                return _contextAccessor.HttpContext.Session.GetString("activedirectory.userName");
            }
            set
            {
                _contextAccessor.HttpContext.Session.SetString("activedirectory.userName", value);
            }
        }

        #region IDisposable Support

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
