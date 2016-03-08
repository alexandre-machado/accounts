using Microsoft.Extensions.OptionsModel;
using System;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;

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
            var emailMD5 = "6ae58efd6a897446e8e1c94b44b5b28a"; // GetMd5Hash(identity.Name);
            return $"https://www.gravatar.com/avatar/{emailMD5}?s={size}";
            //return string.Format(_appSettings.SharePointImageUrl, user.UserName, _appSettings.ActiveDirectoryDomain);
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
