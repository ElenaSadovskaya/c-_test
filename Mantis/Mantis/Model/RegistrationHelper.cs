using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;

namespace Mantis
{
    public class RegistrationHelper : BaseHelper
    {
       
        public RegistrationHelper(ApplicationManager manager) : base(manager) { }



        public void Register(AccountData account)
        {
            OpenMainPage();
            OpenRegForm();
            FillRegForm(account);
            SubmitReg();
        }

        public void OpenRegForm()
        {
            driver.FindElement(By.LinkText("Signup for a new account")).Click();
        }

        public void SubmitReg()
        {
            driver.FindElement(By.XPath("//input[@value='Signup']")).Click();
        }

        public void FillRegForm(AccountData account)
        {
            driver.FindElement(By.Name("username")).SendKeys(account.Name);
            driver.FindElement(By.Name("email")).SendKeys(account.Email);
        }

        public void OpenMainPage()
        {
            manager.Driver.Url = "http://localhost/mantisbt-2.22.1/login_page.php";
        }
    }
}
