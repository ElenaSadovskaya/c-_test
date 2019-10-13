using NUnit.Framework;
using System.Collections.Generic;

namespace Education_web_test
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData newData = new ContactData("1", "2", "3");
            app.Contact.CheckContactExist();
            List<ContactData> oldContact = ContactData.GetAll();
            ContactData toBeModified = oldContact[0];
            app.Contact.Modify(toBeModified, newData);
            app.Navigation.OpenHomePage();
            List<ContactData> newContact = ContactData.GetAll();
            oldContact[0].Firstname = newData.Firstname;
            oldContact[0].LastName = newData.LastName;
            oldContact[0].Address = newData.Address;
            oldContact.Sort();
            newContact.Sort();
            Assert.AreEqual(newContact, oldContact);
            foreach (ContactData contact in newContact)
            {

                if (contact.Id == toBeModified.Id)
                {
                    Assert.AreEqual(contact.LastName, newData.LastName);
                }

            }
        }
    }
}
