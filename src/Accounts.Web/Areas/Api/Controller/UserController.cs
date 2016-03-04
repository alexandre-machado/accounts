using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Authorization;
using Accounts.Web.Areas.Admin.Model;
using Accounts.Web.Services.Domain;
using Common.Pagination;

namespace Accounts.Web.Areas.Api.Controllers
{
    //[Authorize]
    public class UserController : BaseController
    {
        private UserDomain _userDomain;

        public UserController(UserDomain userDomain)
        {
            _userDomain = userDomain;
        }

        public IActionResult Search(UserSearchModel model)
        {
            return Json(_userDomain.GetAll().ToPaginated(model));
        }
    }
}
