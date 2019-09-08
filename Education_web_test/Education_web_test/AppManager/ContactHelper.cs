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
    public class ContactHelper : BaseHelper
    {


        public ContactHelper(ApplicationManager manager) : base(manager)
        {
        }

        internal void RemoveContact(int index, object contact)
        {
            throw new NotImplementedException();
        }

        public ContactHelper Create(ContactData contact)
        {
            NewContact();
            FillContactData(contact);
            SubmitContact();
            return this;
        }

        public ContactHelper Modify (int index, ContactData newData)
        {
            manager.Navigation.OpenHomePage();
            if (IsElementPresent(By.XPath("(//input[@name='selected[]'])[1]")))
            {

            }
            else
            {
                NewContact();
                FillContactData(new ContactData("1", "1", "1"));
                SubmitContact();
                manager.Navigation.OpenHomePage();
            }
            SelectContact(index);
            ModifySelectedContact();
            FillContactData(newData);
            UpdateContact();
            return this;

        }

        public ContactHelper RemoveContact(int index, ContactData contact)
        {
            manager.Navigation.OpenHomePage();
            if (IsElementPresent(By.XPath("(//input[@name='selected[]'])[1]")))
            {
            }
            else
            {
                NewContact();
                FillContactData(contact);
                SubmitContact();
                manager.Navigation.OpenHomePage();
            }
            SelectContact(index);
            DeleteContact();
            return this;
        }


        public ContactHelper NewContact()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }


        public ContactHelper UpdateContact()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public ContactHelper ModifySelectedContact()
        {
            driver.FindElement(By.CssSelector("img[title=\"Edit\"]")).Click();
            return this;
        }

        
        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])["+ index +"]")).Click();
            return this;
        }

        public ContactHelper DeleteContact()
        {
            driver.FindElement(By.XPath("(//input[@value='Delete'])")).Click();
            driver.SwitchTo().Alert().Accept();
            return this;
        }

        public ContactHelper FillContactData(ContactData contact)
        {
            Type(By.Name("firstname"), contact.Firstname);
            Type(By.Name("middlename"), contact.Middlename);
            Type(By.Name("lastname"), contact.LastName);
            Type(By.Name("nickname"), contact.Nickname);
            Type(By.Name("title"), contact.Title);
            Type(By.Name("company"), contact.Company);
            Type(By.Name("address"), contact.Address);
            Type(By.Name("home"), contact.Home);
            Type(By.Name("mobile"), contact.Mobile);
            Type(By.Name("work"), contact.Work);
            Type(By.Name("fax"), contact.Fax);
            Type(By.Name("email"), contact.Email);
            Type(By.Name("email2"), contact.Email2);
            Type(By.Name("email3"), contact.Email3);
            Type(By.Name("homepage"), contact.Homepage);
            Type(By.Name("address2"), contact.Adress2);
            Type(By.Name("phone2"), contact.Phone2);
            Type(By.Name("notes"), contact.Notes);
            return this;
        }


        public ContactHelper SubmitContact()
        {
            driver.FindElement(By.XPath("(//input[@name='submit'])[2]")).Click();
            return this;
        }
    }
}
