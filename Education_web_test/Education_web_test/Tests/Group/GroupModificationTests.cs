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
            GroupData newData = new GroupData("zzz","","");
            int index = 1;
            app.Group.Modify (index, newData);
            app.Navigation.OpenGroupTab();
            
        }
    }
}
