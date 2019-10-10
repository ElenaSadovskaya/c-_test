using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Education_web_test
{
    [TestFixture]

    public class ContactRemovalTests : ContactTestBest
    {
        [Test]
        public void ContactRemoval()
        {
            app.Contact.CheckContactExist();
            List<ContactData> oldContact = ContactData.GetAll();
            ContactData toBeRemoved = oldContact[0];
            app.Contact.RemoveContact(toBeRemoved);
            app.Navigation.OpenContacts();
            List<ContactData> newContact = ContactData.GetAll();
            oldContact.RemoveAt(0);
            Assert.AreEqual(oldContact, newContact);
            foreach (ContactData contact in newContact)
            {
                Assert.AreNotEqual(contact.Id, toBeRemoved.Id);
            }

        }
        
    }
}
