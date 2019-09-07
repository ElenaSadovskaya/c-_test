﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace Education_web_test
{
    public class GroupHelper : BaseHelper
    {
        
        public GroupHelper(ApplicationManager manager) : base(manager)
        {
            
        }

        public GroupHelper Modify(GroupData newData)
        {
            manager.Navigation.OpenGroupTab();
            SelectGroup(1);
            InitialModifyGroup();
          return this;
        }

        public GroupHelper Create(GroupData group)
        {
            manager.Navigation.OpenGroupTab();
            CreateNewGroup();
            FillGroupForm(group);
            SubmitGroupForm();
            return this;
        }

        public GroupHelper Modify(int index , GroupData newData)
        {
            manager.Navigation.OpenGroupTab();
            SelectGroup(1);
            InitialModifyGroup();
            FillGroupForm(newData);
            SubmitGroupModification();
            return this;
        }

        public GroupHelper Detele()
        {
            manager.Navigation.OpenGroupTab();
            SelectGroup(1);
            DeleteGroup();
            return this;
        }

        public GroupHelper CreateNewGroup()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }

        public GroupHelper FillGroupForm(GroupData group)
        {
            driver.FindElement(By.Name("group_name")).Click();
            driver.FindElement(By.Name("group_name")).Clear();
            driver.FindElement(By.Name("group_name")).SendKeys(group.Name);
            driver.FindElement(By.Name("group_header")).Click();
            driver.FindElement(By.Name("group_header")).Clear();
            driver.FindElement(By.Name("group_header")).SendKeys(group.Header);
            driver.FindElement(By.Name("group_footer")).Click();
            driver.FindElement(By.Name("group_footer")).Clear();
            driver.FindElement(By.Name("group_footer")).SendKeys(group.Footer);
            return this;
        }

        
        public GroupHelper SubmitGroupForm()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }
        public GroupHelper DeleteGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
            return this;
        }

        public GroupHelper InitialModifyGroup()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }

        public GroupHelper SelectGroup(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();
            return this;
        }

        public GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update"));
            return this;
        }
    }
}
