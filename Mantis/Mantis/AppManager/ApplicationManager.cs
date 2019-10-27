using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace Mantis
{
    public class ApplicationManager
    {
        public IWebDriver driver;
        public string baseURL;

        public RegistrationHelper Registration { get; private set; }
        public FtpHelper Ftp { get; private set; }
        public LoginHelper loginHelper;
        public AdminHelper admin;
        public ProjectManagementHelper project;
        public APIHelper api;
        public static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();


        private ApplicationManager()
        {

            driver = new FirefoxDriver();
            baseURL = "http://localhost/mantisbt-2.22.1";
            Registration = new RegistrationHelper(this);
            Ftp = new FtpHelper(this);
            loginHelper = new LoginHelper(this);
            admin = new AdminHelper(this, baseURL);
            project = new ProjectManagementHelper(this);
            api = new APIHelper(this);
        }


        public static ApplicationManager GetInstance()
        {
            if (!app.IsValueCreated)
            {
                ApplicationManager NewInstance = new ApplicationManager();
                NewInstance.Driver.Url =NewInstance.baseURL + "/login_page.php";
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

        public AdminHelper Admin
        {
            get
            {
                return admin;
            }
        }

        public ProjectManagementHelper Project
        {
            get
            {
                return project;
            }
        }

        public APIHelper API
        {
            get
            {
                return api;
            }
        }
    }
}

