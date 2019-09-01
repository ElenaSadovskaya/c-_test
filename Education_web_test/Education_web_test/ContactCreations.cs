using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace Education_web_test
{
    [TestFixture]
    class ContactCreations: TestBase
    {

        [Test]
        public void ContactCreation()
        {
            OpenHomePage();
            Login(new AccountData("admin", "secret"));
            CreateNewContact(new ContactData("1", "2", "3"));
            OpenContacts();
            Logout();
        }

    }
}
