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
            app.Group.CheckGroupExist();
            app.Group.Detele();
            app.Navigation.OpenGroupTab();
                       
        }

    }
}
