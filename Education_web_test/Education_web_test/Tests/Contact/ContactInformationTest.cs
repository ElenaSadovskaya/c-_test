using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Education_web_test
{

    [TestFixture]
    public class ContactInformationTest : ContactTestBest
    {
        [Test]
        public void TestContactInformation()
        {
            ContactData fromTable = app.Contact.GetInformationFromTable(0);
            ContactData fromForm = app.Contact.GetInformationFromForm(0);

            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromTable.Address);
            Assert.AreEqual(fromTable.AllPhone, fromTable.AllPhone);
            Assert.AreEqual(fromTable.AllEmail, fromTable.AllEmail);
        }

        [Test]
        public void TestContactInformationFromDetails()
        {
            string dataFromDetails = app.Contact.GetInformationFromDetails(0);
            ContactData dataFromForm = app.Contact.GetInformationFromForm(0);
            string text = (dataFromForm.AllData).ToString();
            Assert.AreEqual(dataFromDetails, (dataFromForm.AllData).ToString());

        }
    }
}
