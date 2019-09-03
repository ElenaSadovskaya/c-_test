using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Education_web_test
{
    [TestFixture]
    class ContactCreations: TestBase
    {

        [Test]
        public void ContactCreation()
        {
            ContactData contact = new ContactData("123","123","434324");
            app.Contact.NewContact();
            app.Contact.Create(contact);
            app.Navigation.OpenContacts();
            app.Auth.Logout();

        }

        
    }
}
