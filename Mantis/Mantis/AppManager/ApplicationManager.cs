using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;

namespace Mantis
{
    public class ApplicationManager
    {
        public IWebDriver driver;
        public string baseURL;

        public RegistrationHelper Registration { get; private set; }
        public FtpHelper Ftp { get; private set; }
        public LoginHelper loginHelper;
        public NavigationHelper navigator;
        public ProjectManagementHelper project;
        public static ThreadLocal <ApplicationManager> app = new ThreadLocal<ApplicationManager>();

     
        private ApplicationManager()
        {

            driver = new FirefoxDriver();
            baseURL = "http://localhost/mantisbt-2.22.1";
            Registration = new RegistrationHelper(this);
            Ftp = new FtpHelper(this);
            loginHelper = new LoginHelper(this);
            navigator = new NavigationHelper(this, baseURL);
            project = new ProjectManagementHelper(this);

        }

         
        public static ApplicationManager GetInstance()
        {
            if (! app.IsValueCreated) 
            {
                ApplicationManager NewInstance = new ApplicationManager();
                NewInstance.Driver.Url = "http://localhost/mantisbt-2.22.1/login_page.php";
                app.Value = NewInstance;
              
            }
            return app.Value;
        }

        ~ApplicationManager()
        {

            try
            {
                driver.Quit();
            }
            catch (Exception)
            {

            }
        }


        public IWebDriver Driver
        {

            get
            {
                return driver;
            }

        }

        public LoginHelper Auth
        {
            get
            {
                return loginHelper;
            }
        }

        public NavigationHelper Navigation
        {
            get
            {
                return navigator;
            }
        }

        public ProjectManagementHelper Project
        {
            get
            {
                return project;
            }
        }
    }
}
