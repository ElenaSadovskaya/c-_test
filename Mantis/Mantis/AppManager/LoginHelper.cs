using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace Mantis
{
    public class LoginHelper : BaseHelper
    {
        public LoginHelper(ApplicationManager manager) : base(manager)
        {

        }
        public void Login(AccountData account)
        {
            Type(By.Id("username"), account.Name);
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
            Type(By.Id("password"), account.Password);
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
        }

    }
}
