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
            int index = 1;
            ContactData contact = new ContactData("1", "1", "1");
            app.Contact.RemoveContact(index, contact);
            app.Navigation.OpenContacts();
            
        }
    }

}
