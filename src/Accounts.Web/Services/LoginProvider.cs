using System;
using System.Text.RegularExpressions;

namespace Accounts.Web.Services
{
    public class Login
    {
        private string _login;
        public enum LoginEnum
        {
            ActiveDirectory,
            Email,
            SomenteUsuário
        }

        public Login(string login)
        {
            _login = login;
            if (validaActiveDirectory(login))
            {
                TipoLogin = LoginEnum.ActiveDirectory;
                UserName = Regex.Replace(_login, @"^[A-Za-z0-9\._-]+\\", string.Empty);
                Domain = Regex.Replace(_login, @"\\[A-Za-z0-9\._-]+$", string.Empty);
            }
            else if (validaEmail(login))
            {
                TipoLogin = LoginEnum.Email;
                Domain = Regex.Replace(_login, @"^[A-Za-z0-9\._-]+\@", string.Empty);
                UserName = Regex.Replace(_login, @"\@[A-Za-z0-9\._-]+$", string.Empty);
            }
            else if (validaSomenteUsuário(login))
            {
                TipoLogin = LoginEnum.SomenteUsuário;
                UserName = _login;
            }
            else
                throw new ArgumentException($"Formato do login inválido para: '{login}'", "login");
        }

        public static bool ValidaLogin(string login)
        {
            return validaActiveDirectory(login) || validaEmail(login) || validaSomenteUsuário(login);
        }

        private static bool validaActiveDirectory(string login)
        {
            return Regex.IsMatch(login, @"^[A-Za-z0-9\._-]+\\[A-Za-z0-9\._-]+$");
        }

        private static bool validaEmail(string login)
        {
            return Regex.IsMatch(login, @"^[A-Za-z0-9\._-]+\@[A-Za-z0-9\._-]+$");
        }

        private static bool validaSomenteUsuário(string login)
        {
            return Regex.IsMatch(login, @"^[A-Za-z0-9\._-]+$");
        }

        public string Domain { get; private set; }
        public string UserName { get; private set; }

        public string ActiveDirectoryFormat { get { return $"{Domain}\\{UserName}"; } }
        public string EmailFormat { get { return $"{UserName}@{Domain}"; } }

        public bool HasDomain { get { return Domain == null; } }
        public LoginEnum TipoLogin { get; set; }
    }
}