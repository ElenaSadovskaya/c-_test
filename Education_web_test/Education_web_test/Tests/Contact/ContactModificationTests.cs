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
        [Test]
        public void  ContactModificationTest()
        {
            ContactData newData = new ContactData("165ffd46frtyuk5423", "123rvbnewre", "43bnm4rewrew324");
            app.Contact.CheckContactExist();
            List<ContactData> oldContact = app.Contact.GetContactList();
            app.Contact.Modify(0, newData);
            app.Navigation.OpenHomePage();
            List<ContactData> newContact = app.Contact.GetContactList();
            oldContact[0].Firstname = newData.Firstname;
            oldContact[0].LastName = newData.LastName;
            oldContact[0].Address = newData.Address;
            oldContact.Sort();
            newContact.Sort();
            Assert.AreEqual(oldContact, newContact);
        }
    }
}
