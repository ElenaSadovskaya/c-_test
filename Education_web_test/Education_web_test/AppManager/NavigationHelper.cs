using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace Education_web_test
{
    public class NavigationHelper: BaseHelper
    {
        public string baseURL;

        public NavigationHelper(IWebDriver driver, string baseURL) : base(driver)
        {
        this.baseURL = baseURL;
        }

        
        public void OpenHomePage()
        {
            driver.Navigate().GoToUrl(baseURL);
        }

        public void OpenGroupTab()
        {
            driver.FindElement(By.LinkText("groups")).Click();
        }

        public void ReturnToGroupPage()
        {
            driver.FindElement(By.LinkText("groups")).Click();
        }
               

        public void OpenContacts()
        {
            driver.FindElement(By.LinkText("home")).Click();
        }

       


    }
}
