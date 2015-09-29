using Accounts.Web.Models;

namespace Models.ViewModel
{
    public class LoginViewModel
    {
        public string Login { get; internal set; }
        public string Password { get; internal set; }
        public bool RememberMe { get; internal set; }
    }
}