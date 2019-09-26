using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;


namespace Education_web_test
{
    [TestFixture]
    public class GroupsRemoval : AuthTestBase
    {
               
        [Test]
        public void GroupRemoval()
        {
            app.Group.CheckGroupExist();
            List<GroupData> oldGroups = app.Group.GetGroupList();
            app.Group.Detele(0);
            app.Navigation.OpenGroupTab();
            List<GroupData> newGroups = app.Group.GetGroupList();
            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups);
        }

    }
}
