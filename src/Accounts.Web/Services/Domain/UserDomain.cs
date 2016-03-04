using Accounts.Web.Models;

namespace Accounts.Web.Services.Domain
{
    public class UserDomain : BaseDomain<ApplicationUser>
    {
        public UserDomain(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}
