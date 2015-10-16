using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accounts.Web.Models.ViewModel
{
    public class IndexViewModel
    {
        public string FullName { get; set; }
        public string Login { get; set; }
        public string Domain { get; set; }
        public string ImagePath { get { return $"~/profile-image/{Domain}/{Login}"; } }
    }
}
