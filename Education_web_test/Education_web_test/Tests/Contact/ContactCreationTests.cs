using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace Education_web_test
{
    [TestFixture]
    class ContactCreationTests : AuthTestBase
    {

        [Test]
        public void ContactCreation()
        {
            ContactData contact = new ContactData("123","123","434324");
            app.Contact.Create(contact);
            app.Navigation.OpenContacts();
            

        }

        
    }
}
