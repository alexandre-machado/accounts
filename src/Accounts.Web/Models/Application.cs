using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accounts.Web.Models
{
    public class Application
    {
        public Guid ApplicationID { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
    }
}
