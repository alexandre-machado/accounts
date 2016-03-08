using Microsoft.Extensions.OptionsModel;
using System;
using System.Security.Cryptography;
using System.Security.Principal;

namespace Accounts.Web.Services.UserImageProviders
{
    public class GravatarProvider : IUserImageProvider
    {
        private AppSettings _appSettings;

        public GravatarProvider(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public string UserImageUrl(IIdentity identity, int size = 100)
        {
            var emailMD5 = "6ae58efd6a897446e8e1c94b44b5b28a";
            return $"https://www.gravatar.com/avatar/{emailMD5}?s={size}";
            //return string.Format(_appSettings.SharePointImageUrl, user.UserName, _appSettings.ActiveDirectoryDomain);
        }
    }
}
