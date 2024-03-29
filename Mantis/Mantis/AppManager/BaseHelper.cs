﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace Mantis
{
    public class BaseHelper
    {
        public ApplicationManager manager;
        public IWebDriver driver;

        public BaseHelper(ApplicationManager manager)
        {
            this.manager = manager;
            driver = manager.Driver;
        }

        public void Type(By locator, string text)
        {
            if (text != null)
            {
                driver.FindElement(locator).Click();
                driver.FindElement(locator).Clear();
                driver.FindElement(locator).SendKeys(text);
            }

        }
        
        public bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public bool ElementExist()
        {
            if (IsElementPresent(By.XPath(("//a[contains(@href,'manage_proj_edit_page.php')]"))))
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        
    }
}