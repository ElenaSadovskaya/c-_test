using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace Education_web_test
{
    [TestFixture]
    public class ContactModificationTests: TestBase
    {
        [Test]
        public void  ContactModificationTest()
        {
            ContactData newData = new ContactData("123", "3464", "4546");
            int index = 1;
            app.Contact.Modify(index , newData);
            app.Navigation.OpenHomePage();
            app.Auth.Logout();


        }
    }
}
