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
        public IWebDriver driver;
        public string baseURL;
        public NavigationHelper navigator;
        public GroupHelper group;
        public ContactHelper contact;
        public LoginHelper loginHelper;

        public ApplicationManager()
        {

            driver = new FirefoxDriver();
            baseURL = "http://localhost/addressbook/";
            loginHelper = new LoginHelper(this);
            navigator = new NavigationHelper(this, baseURL);
            group = new GroupHelper(this);
            contact = new ContactHelper(this);

            
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

        public IWebDriver Driver
        {

            get
            {
                return driver;
            }

        }
    }
}
