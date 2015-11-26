namespace Accounts.Web.Controllers
{
    using Microsoft.AspNet.Authorization;
    using Microsoft.AspNet.Mvc;

    [Authorize]
    public class BaseController : Controller
    {
        public BaseController()
        {
        }
    }
}
