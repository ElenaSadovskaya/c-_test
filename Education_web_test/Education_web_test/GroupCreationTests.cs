using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace Education_web_test
{
    [TestFixture]
    class GroupCreationTests: TestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            OpenHomePage();
            Login(new AccountData("admin", "secret"));
            OpenGroupTab();
            CreateNewGroup();
            FillGroupForm(new GroupData("aaa"));
            SubmitGroupForm();
            ReturnToGroupPage();
            Logout();
        }

    }
}
