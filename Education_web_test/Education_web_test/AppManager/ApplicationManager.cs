using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace Education_web_test
{
    public class ApplicationManager
    {
        protected IWebDriver driver;
        private StringBuilder verificationErrors;
        protected string baseURL;
        public NavigationHelper navigator;
        public GroupHelper group;
        public ContactHelper contact;
        public LoginHelper loginHelper;

        public ApplicationManager()
        {
            loginHelper = new LoginHelper(driver);
            navigator = new NavigationHelper(driver, baseURL);
            group = new GroupHelper(driver);
            contact = new ContactHelper(driver);

            driver = new FirefoxDriver();
            baseURL = "http://localhost/addressbook/";
            verificationErrors = new StringBuilder();

        }

        public LoginHelper Auth
        {
            get
            {
                return loginHelper;
            }
        }


        public void Stop()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }

        public NavigationHelper Navigation
        {
            get
            {
                return navigator;
            }
        }

        public ContactHelper Contact
        {
            get
            {
                return contact;
            }
        }

        public GroupHelper Group
        {
            get
            {
                return group;
            }
        }
    }
}
