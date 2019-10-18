using System;
using NUnit.Framework;
using System.Collections.Generic;

namespace Desktops_test
{
    [TestFixture]
    public class GroupCreationsTests : TestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            GroupData newGroup = new GroupData()
            {
                Name = "test"
            };
            app.Groups.AddNewGroup(newGroup);
            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Add(newGroup);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(newGroups, oldGroups);
        }
    }
}
