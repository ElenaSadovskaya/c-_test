using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace Education_web_test
{
    [TestFixture]
    public class GroupModificationTests : TestBase
    {
        [Test]
        public void GroupModificationsTest()
        {
            GroupData newData = new GroupData("zzz");

            app.Group.Modify (newData);
            app.Navigation.ReturnToGroupPage();
            app.Auth.Logout();
        }
    }
}
