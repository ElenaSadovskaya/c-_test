using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;


namespace Education_web_test
{
    [TestFixture]
    public class GroupsRemoval : GroupTestBase
    {
               
        [Test]
        public void GroupRemoval()
        {
            app.Group.CheckGroupExist();
            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData toBeRemoved = oldGroups[0];
            app.Group.Detele(toBeRemoved);
            app.Navigation.OpenGroupTab();
            List<GroupData> newGroups = GroupData.GetAll();
            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                Assert.AreNotEqual(group.Id, toBeRemoved.Id);
            }
        }

    }
}
