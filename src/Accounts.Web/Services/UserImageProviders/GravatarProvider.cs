using Microsoft.Extensions.OptionsModel;
using System;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;

namespace Accounts.Web.Services.UserImageProviders
{
    public class GravatarProvider : IUserImageProvider
    {
        // https://en.gravatar.com/site/implement/images/

        private AppSettings _appSettings;
        private ApplicationUserManager _userManager;

        public GravatarProvider(
            IOptions<AppSettings> appSettings
            , ApplicationUserManager userManager)
        {
            _appSettings = appSettings.Value;
            _userManager = userManager;
        }

        public string UserImageUrl(IIdentity identity, string uriScheme, int size = 100)
        {
            var email = _userManager.FindByNameAsync(identity.Name);
            email.Wait();
            var emailMD5 = GetMd5Hash(email.Result.Email);

            switch (uriScheme)
            {
                case "https":
                    return $"https://secure.gravatar.com/avatar/{emailMD5}?s={size}";
                default:
                    return $"http://www.gravatar.com/avatar/{emailMD5}?s={size}";
            }
        }

        private string GetMd5Hash(string input)
        {
            using (var md5 = MD5.Create())
            {
                // Convert the input string to a byte array and compute the hash.
                byte[] data = md5.ComputeHash(Encoding.UTF8.GetBytes(input));

                // Create a new Stringbuilder to collect the bytes
                // and create a string.
                StringBuilder sBuilder = new StringBuilder();

                // Loop through each byte of the hashed data 
                // and format each one as a hexadecimal string.
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }

                // Return the hexadecimal string.
                return sBuilder.ToString();
            }
        }
    }
}
