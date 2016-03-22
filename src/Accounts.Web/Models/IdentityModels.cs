using Microsoft.AspNet.Identity.EntityFramework;
using System.DirectoryServices.AccountManagement;

namespace Accounts.Web.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {

        }

        // REVIEW: considerar usar o automapper futuramente
        public ApplicationUser(UserPrincipal userPrincipal)
        {
            Email = userPrincipal.EmailAddress;
            NormalizedUserName = userPrincipal.DisplayName;
            UserName = userPrincipal.SamAccountName;
        }
    }
}
