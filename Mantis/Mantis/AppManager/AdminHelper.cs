using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using SimpleBrowser.WebDriver;
using System.Text.RegularExpressions;

namespace Mantis
{
    public class AdminHelper : BaseHelper
    {
        private string baseURL;

        public AdminHelper(ApplicationManager manager, string baseURL) : base(manager)
        {
            this.baseURL = baseURL;
        }


        public List<AccountData> GetAllAccounts()
        {
            List<AccountData> accounts = new List<AccountData>();
            IWebDriver driver = OpenAppAndLogin();
            driver.Url = baseURL + "/manage_user_page.php";
            IList<IWebElement> rows = driver.FindElements(By.TagName("tbody"))[0].FindElements(By.CssSelector("tr"));
            foreach (IWebElement row in rows)
            {
                IWebElement link = row.FindElement(By.TagName("a"));
                string name = link.Text;
                string href = link.GetAttribute("href");
                Match m = Regex.Match(href, @"\d+$");
                string id = m.Value;
                accounts.Add(new AccountData
                {
                    Name = name,
                    Id = id
                });
            }
            return accounts;
        }


        public void DeleteAccount(AccountData account)
        {
            IWebDriver driver = OpenAppAndLogin();
            driver.Url = baseURL + "manage_user_edit_page.php?user_id=" + account.Id;
            driver.FindElement(By.XPath("//input[@value='Delete User']")).Click();
            driver.FindElement(By.XPath("//input[@value='Delete Account']")).Click();
        }

        public IWebDriver OpenAppAndLogin()
        {
            IWebDriver driver = new SimpleBrowserDriver();
            driver.Url = baseURL + "/login_page.php";
            driver.FindElement(By.Id("username")).SendKeys("administrator");
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
            driver.FindElement(By.Id("password")).SendKeys("root");
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
            return driver;
        }

        public void OpenProjectPage()
        {
            if (driver.Url == baseURL + "/manage_proj_page.php")
            {
                return;
            }
            driver.Navigate().GoToUrl(baseURL + "/manage_proj_page.php");
         }

      

               
        
    }
}
