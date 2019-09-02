using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace Education_web_test
{
    [TestFixture]
    public class GroupCreationTests: TestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            app.Navigation.OpenHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
            app.Navigation.OpenGroupTab();
            app.Group.CreateNewGroup();
            app.Group.FillGroupForm(new GroupData("aaa"));
            app.Group.SubmitGroupForm();
            app.Navigation.ReturnToGroupPage();
            app.Auth.Logout();
        }

    }
}
