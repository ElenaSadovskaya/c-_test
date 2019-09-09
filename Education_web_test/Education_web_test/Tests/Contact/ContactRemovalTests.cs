using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Education_web_test
{
    [TestFixture]

    public class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemoval()
        {
            app.Contact.CheckContactExist();
            app.Contact.RemoveContact();
            app.Navigation.OpenContacts();

        }
        
    }
}
