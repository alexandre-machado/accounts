using Microsoft.Extensions.OptionsModel;
using System;
using System.Security.Principal;

namespace Accounts.Web.Services.UserImageProviders
{
    public class SharePointProvider : IUserImageProvider
    {
        private AppSettings _appSettings;

        public SharePointProvider(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public string UserImageUrl(IIdentity identity, int size = 0)
        {
            var user = new Login(identity.Name);
            return string.Format(_appSettings.SharePointImageUrl, user.UserName, _appSettings.ActiveDirectoryDomain);
        }
    }
}
