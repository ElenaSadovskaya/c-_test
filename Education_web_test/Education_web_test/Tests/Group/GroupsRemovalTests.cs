using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace Education_web_test
{
    [TestFixture]
    public class GroupsRemoval : TestBase
    {
               
        [Test]
        public void GroupRemoval()
        {
            app.Group.Detele();
            app.Navigation.ReturnToGroupPage();
            app.Auth.Logout();

        }

        


    }
}
