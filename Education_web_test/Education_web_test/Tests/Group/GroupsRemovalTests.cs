using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace Education_web_test
{
    [TestFixture]
    public class GroupsRemoval : AuthTestBase
    {
               
        [Test]
        public void GroupRemoval()
        {

            GroupData group = new GroupData("test", "test", "test");
            int index = 1;
            app.Group.Detele(index, group);
            app.Navigation.OpenGroupTab();
            

        }

    }
}
