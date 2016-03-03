using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

namespace Accounts.Web.Controllers
{
    public class OAuth2Controller : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
