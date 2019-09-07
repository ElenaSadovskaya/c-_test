using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Education_web_test
{
    [TestFixture]

    public class ContactRemovalTests : TestBase
        {
        [Test]
        public void ContactRemoval()
        {
                app.Contact.RemoveContact();
                app.Navigation.OpenContacts();
                app.Auth.Logout();
            }
        }

}
