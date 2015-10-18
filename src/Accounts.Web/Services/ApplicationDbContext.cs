using Accounts.Web.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Accounts.Web.Services
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

    }
}
