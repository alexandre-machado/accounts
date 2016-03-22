using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;

namespace Accounts.Web.Services.UserImageProviders
{
    public interface IUserImageProvider
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="identity">User identity</param>
        /// <param name="size">Image size</param>
        /// <param name="uriScheme">Uri protocol: http, https</param>
        /// <returns></returns>
        string UserImageUrl(IIdentity identity, string uriScheme = "http", int size = 100);
    }
}
