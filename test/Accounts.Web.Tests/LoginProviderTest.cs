using Accounts.Web.Services;
using Xunit;

namespace Accounts.Web.Tests
{
	public class LoginProviderTest
	{
		[Fact]
        public void validaEntradasCoretas()
        {
            Assert.True(Login.ValidaLogin(@"teste@teste"));
            Assert.True(Login.ValidaLogin(@"teste"));
            Assert.True(Login.ValidaLogin(@"teste\teste"));
        }

        [Fact]
        public void validaUserNameDominio()
        {
            var login = new Login(@"user@domain");
            Assert.True(login.Domain == "domain");
            Assert.True(login.UserName == "user");
            Assert.True(login.ActiveDirectoryFormat == @"domain\user");

            login = new Login(@"domain\user");
            Assert.True(login.Domain == "domain");
            Assert.True(login.UserName == "user");
            Assert.True(login.EmailFormat == @"user@domain");

            login = new Login(@"user");
            Assert.True(login.Domain == null);
            Assert.True(login.UserName == "user");
        }

        [Fact]
        public void validaEntradasIncoretas()
        {
            Assert.False(Login.ValidaLogin(@"test este"));
            Assert.False(Login.ValidaLogin(@"te@teste\te"));
            Assert.False(Login.ValidaLogin(@"teste\teste@teste"));
        }
    }
}