using System;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;
using System.IO;

namespace Mantis
{

    [TestFixture]
    public class AccountCreationTest : TestBase
    {
        [OneTimeSetUp]
        public void SetUpConfig()
        {
            app.Ftp.BackupFile("/config_defaults_inc.php");
            using (Stream localFile = File.Open("/config_defaults_inc.php", FileMode.Open))
            {
                app.Ftp.Upload("/config_defaults_inc.php", localFile);
            }
                
        }


        [Test]
        public void TestAccountRegistration()
        {
           
            AccountData account = new AccountData()
            {
                Name = "t4534",
                Password = "password",
                Email = "testuser@localhost.localhostdomain"
            };

           List<AccountData> accounts = app.Admin.GetAllAccounts();
           AccountData existingAccount = accounts.Find(x => x.Name == account.Name);
           if (existingAccount != null)
           {
               app.Admin.DeleteAccount(existingAccount);
           }
            

           app.Registration.Register(account);
            

        }

        [OneTimeTearDown]
        public void RestoreConfig()
        {
            app.Ftp.RestoreBackupFile("");
        }
    }
}
