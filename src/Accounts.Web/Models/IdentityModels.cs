using Microsoft.AspNet.Identity.EntityFramework;

namespace Accounts.Web.Models
{
    public class ApplicationUser : IdentityUser
    {
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
    }
}
