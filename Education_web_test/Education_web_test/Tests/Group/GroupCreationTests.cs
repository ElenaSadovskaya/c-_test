using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;


namespace Education_web_test
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {
        [Test]

        public void GroupCreationTest()
        {
            GroupData group = new GroupData("aa");

            List<GroupData> oldGroups = app.Group.GetGroupList();
            app.Group.Create(group);
            app.Navigation.OpenGroupTab();

            List<GroupData> newGroups = app.Group.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }

    }
}
