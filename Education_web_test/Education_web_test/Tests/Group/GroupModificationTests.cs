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

        public static IEnumerable<GroupData> RandomGroupDataProvider()
        {
            List<GroupData> newData = new List<GroupData>();
            for (int i = 0; i < 5; i++)
            {
                newData.Add(new GroupData(GenerateRandomString(30))
                {
                    Header = GenerateRandomString(100),
                    Footer = GenerateRandomString(100)
                });
            }
            return newData;
        }
        [Test, TestCaseSource("RandomGroupDataProvider")]

        public void GroupModificationsTest(GroupData newData)
        {

            app.Group.CheckGroupExist();
            List<GroupData> oldGroups = app.Group.GetGroupList();
            GroupData oldData = oldGroups[0];
            app.Group.Modify(0, newData);
            app.Navigation.OpenGroupTab();
            List<GroupData> newGroups = app.Group.GetGroupList();
            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
            foreach (GroupData group in newGroups)
            {
                if (group.Id == oldData.Id)
                {
                    Assert.AreEqual( newData.Name, group.Name);
                }
            }

        }
    }
}
