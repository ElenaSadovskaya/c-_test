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
    public class GroupHelper : BaseHelper
    {
        
        public GroupHelper(ApplicationManager manager) : base(manager)
        {
            
        }


        public GroupHelper Create(GroupData group)
        {
            manager.Navigation.OpenGroupTab();
            CreateNewGroup();
            FillGroupForm(group);
            SubmitGroupForm();
            return this;
        }

        

        public GroupHelper Modify(int t, GroupData newData)
        {
            manager.Navigation.OpenGroupTab();
            SelectGroup(t);
            InitialModifyGroup();
            FillGroupForm(newData);
            SubmitGroupModification();
            return this;
        }
        
        public GroupHelper Detele(int p)
        {
            manager.Navigation.OpenGroupTab();
            SelectGroup(p); 
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
            Type(By.Name("group_name"), group.Name);
            Type(By.Name("group_header"), group.Header);
            Type(By.Name("group_footer"), group.Footer);
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
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index + 1) + "]")).Click();
            return this;
        }

        public GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public GroupHelper CheckGroupExist()
        {
            manager.Navigation.OpenGroupTab();
            if (ElementExist())
            {
            }
            else
            {
                Create(new GroupData("test", "test", "test"));
                manager.Navigation.OpenGroupTab();
            }
            return this;
         }

        public List<GroupData> GetGroupList()
        {
            List<GroupData> groups = new List<GroupData>();
            manager.Navigation.OpenGroupTab();
            ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
            foreach (IWebElement element in elements)
            {
                groups.Add(new GroupData(element.Text));
            }
            return groups;
        }
    }
}
