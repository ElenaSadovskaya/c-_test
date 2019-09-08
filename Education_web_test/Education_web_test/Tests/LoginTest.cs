using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Education_web_test
{
    [TestFixture]
   public  class LoginTest : TestBase
    
    {
        [Test]

        public void LoginWithValidCredentials()
        {
            AccountData account = new AccountData("admin", "secret");
            app.Auth.Logout();
            app.Auth.Login(account);
            Assert.IsTrue(app.Auth.IsLoggedIn(account));
            
        }

        [Test]

        public void LoginWithOutValidCredentials()
        {
            AccountData account = new AccountData("admir4r4n", "fre");
            app.Auth.Logout();
            app.Auth.Login(account);
            Assert.IsFalse(app.Auth.IsLoggedIn(account));
            
        }
    }
}
