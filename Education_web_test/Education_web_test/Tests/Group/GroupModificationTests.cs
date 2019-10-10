using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace Education_web_test
{
    [TestFixture]
    public class GroupModificationTests : GroupTestBase
    {

        [Test]

        public void GroupModificationsTest()
        {
            GroupData newData = new GroupData("0", "1", "2");
            app.Group.CheckGroupExist();
            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData toBeChanged = oldGroups[0];
            app.Group.Modify(toBeChanged, newData);
            app.Navigation.OpenGroupTab();
            List<GroupData> newGroups =GroupData.GetAll();
            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
            foreach (GroupData group in newGroups)
            {
                if (group.Id == toBeChanged.Id)
                {
                    Assert.AreEqual( newData.Name, group.Name);
                }
            }

        }
    }
}
