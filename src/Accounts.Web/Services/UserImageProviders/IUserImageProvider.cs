using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;

namespace Accounts.Web.Services.UserImageProviders
{
    public interface IUserImageProvider
    {
        string UserImageUrl(IIdentity identity, int size = 100);
    }
}
