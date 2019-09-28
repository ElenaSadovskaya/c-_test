using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;

namespace Education_web_test
{
    [TestFixture]
    class ContactCreationTests : AuthTestBase
    {

        [Test]
        public void ContactCreation()
        {
            ContactData contact = new ContactData("165465423","123","434324");
            List<ContactData> oldContact = app.Contact.GetContactList();
            app.Contact.Create(contact);
            app.Navigation.OpenContacts();
            List<ContactData> newContact = app.Contact.GetContactList();
            oldContact.Add(contact);
            oldContact.Sort();
            newContact.Sort();
            Assert.AreEqual(oldContact, newContact);
        }

        
    }
}
