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
            List<ContactData> oldContact = app.Contact.GetContactList();
            app.Contact.RemoveContact(0);
            app.Navigation.OpenContacts();
            List<ContactData> newContact = app.Contact.GetContactList();
            oldContact.RemoveAt(0);
            Assert.AreEqual(oldContact, newContact);

        }
        
    }
}
