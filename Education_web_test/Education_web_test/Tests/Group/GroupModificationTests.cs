using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace Education_web_test
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModificationsTest()
        {

            app.Group.CheckGroupExist();
            List<GroupData> oldGroups = app.Group.GetGroupList();
            GroupData newData = new GroupData("zzz","","");
            app.Group.Modify(0, newData);
            app.Navigation.OpenGroupTab();
            List<GroupData> newGroups = app.Group.GetGroupList();
            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

        }
    }
}
