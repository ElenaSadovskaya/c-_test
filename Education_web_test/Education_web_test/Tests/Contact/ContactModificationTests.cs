using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;

namespace Education_web_test
{
    [TestFixture]
    public class ContactModificationTests: AuthTestBase
    {
        public static IEnumerable<ContactData> RandomGroupDataProvider()
        {
            List<ContactData> newData = new List<ContactData>();
            for (int i = 0; i < 5; i++)
            {
                newData.Add(new ContactData(GenerateRandomString(30), GenerateRandomString(30), GenerateRandomString(30))
                {
                    Firstname = GenerateRandomString(100),
                    LastName = GenerateRandomString(100),
                    Address = GenerateRandomString(100)
                });
            }
            return newData;
        }

        [Test, TestCaseSource("RandomGroupDataProvider")]
        public void  ContactModificationTest(ContactData newData)
        {
            app.Contact.CheckContactExist();
            List<ContactData> oldContact = app.Contact.GetContactList();
            ContactData oldData = oldContact[0];
            app.Contact.Modify(0, newData);
            app.Navigation.OpenHomePage();
            List<ContactData> newContact = app.Contact.GetContactList();
            oldContact[0].Firstname = newData.Firstname;
            oldContact[0].LastName = newData.LastName;
            oldContact[0].Address = newData.Address;
            oldContact.Sort();
            newContact.Sort();
            Assert.AreEqual(oldContact, newContact);

            foreach (ContactData contact in newContact)
            {

                if (contact.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.LastName, contact.LastName);
                }
            }
        }
    }
}
