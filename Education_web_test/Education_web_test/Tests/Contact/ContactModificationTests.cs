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
            ContactData newData = new ContactData("165ffd465423", "123rewre", "434rewrew324");
            app.Contact.CheckContactExist();
            List<ContactData> oldContact = app.Contact.GetContactList();
            app.Contact.Modify(0, newData);
            app.Navigation.OpenHomePage();
            List<ContactData> newContact = app.Contact.GetContactList();
            Assert.AreNotEqual(oldContact, newContact);
        }
    }
}
