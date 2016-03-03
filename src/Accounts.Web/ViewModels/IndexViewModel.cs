using Accounts.Web.ViewModels.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accounts.Web.ViewModels
{
    public class IndexViewModel
    {
        public string FullName { get; set; }
        public string Login { get; set; }
        public List<UserLoginViewModel> Logins { get; set; }
    }
}
