using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Authorization;

namespace Accounts.Web.Areas.Controllers
{
    [Authorize]
    public class UserController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
