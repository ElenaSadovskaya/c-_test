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
        public static IEnumerable<ContactData> RandomGroupDataProvider()
        {
            List<ContactData> contact = new List<ContactData>();
            for (int i = 0; i < 5; i++)
            {
                contact.Add(new ContactData(GenerateRandomString(30), GenerateRandomString(30), GenerateRandomString(30))
                {
                    Firstname = GenerateRandomString(100),
                    LastName = GenerateRandomString(100),
                    Address = GenerateRandomString(100)
                });
            }
            return contact;
        }

        [Test, TestCaseSource("RandomGroupDataProvider")]

        public void ContactCreation(ContactData contact)
        {
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
