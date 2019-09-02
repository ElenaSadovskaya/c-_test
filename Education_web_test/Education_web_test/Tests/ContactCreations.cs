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
            app.Navigation.OpenHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
            app.Contact.NewContact();
            app.Contact.CreateNewContact(new ContactData("1", "2", "3"));
            app.Contact.SubmitContact();
            app.Navigation.OpenContacts();
            app.Auth.Logout();

        }

        
    }
}
