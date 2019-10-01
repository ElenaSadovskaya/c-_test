﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Text.RegularExpressions;


namespace Education_web_test
{
    public class ContactHelper : BaseHelper
    {


        public ContactHelper(ApplicationManager manager) : base(manager)
        {
        }

        

        public ContactHelper Create(ContactData contact)
        {
            NewContact();
            FillContactData(contact);
            SubmitContact();
            return this;
        }

        public ContactHelper Modify (int t, ContactData newData)
        {
            manager.Navigation.OpenHomePage();
            SelectContact(t);
            ModifySelectedContact();
            FillContactData(newData);
            UpdateContact();
            return this;

        }

        

        public ContactHelper RemoveContact(int p)
        {
            manager.Navigation.OpenContacts();
            SelectContact(p);
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
            contactCache = null;
            return this;
        }

        public ContactHelper ModifySelectedContact()
        {
            driver.FindElement(By.CssSelector("img[title=\"Edit\"]")).Click();
            return this;
        }

        
        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index + 1) + "]")).Click();
            return this;
        }

        public ContactHelper DeleteContact()
        {
            driver.FindElement(By.XPath("(//input[@value='Delete'])")).Click();
            driver.SwitchTo().Alert().Accept();
            contactCache = null;
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
            Type(By.Name("address2"), contact.Address2);
            Type(By.Name("phone2"), contact.Phone2);
            Type(By.Name("notes"), contact.Notes);
            return this;
        }


        public ContactHelper SubmitContact()
        {
            driver.FindElement(By.XPath("(//input[@name='submit'])[2]")).Click();
            contactCache = null;
            return this;
        }


        public ContactHelper CheckContactExist()
        {
            manager.Navigation.OpenHomePage();
            if (ElementExist())
            {
            }
            else
            {
                NewContact();
                Create(new ContactData("test", "test", "test"));
                manager.Navigation.OpenHomePage();
            }
            return this;
        }

        private List<ContactData> contactCache = null;

        public List<ContactData> GetContactList()
        {
            if (contactCache == null)
            {
                contactCache = new List<ContactData>();
                manager.Navigation.OpenContacts();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("tr"));
                foreach (IWebElement element in elements)
                {
                    IList<IWebElement> cells = element.FindElements(By.TagName("td"));

                    if (cells.Count != 0)
                    {
                        contactCache.Add(new ContactData(cells[2].Text, cells[1].Text, cells[3].Text)
                        {
                            Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                        }); 
                    }
                }
            }
            return new List<ContactData>(contactCache);
        }

        public ContactData GetInformationFromTable(int index)
        {
            manager.Navigation.OpenHomePage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index].FindElements(By.TagName("td"));
            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allEmail = cells[4].Text;
            string allPhone = cells[5].Text;

            return new ContactData(firstName, lastName, address)
            {
                AllPhone = allPhone,

                AllEmail = allEmail
            };
        }

        public ContactData GetInformationFromForm(int index)
        {
            manager.Navigation.OpenHomePage();
            SelectContact(0);
            ModifySelectedContact();
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");

            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");

            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");
            return new ContactData(firstName, lastName, address)
            {
                Home = homePhone,
                Mobile = mobilePhone,
                Work = workPhone,

                Email = email,
                Email2 = email2,
                Email3 = email3
            };
        }

        public string GetInformationFromDetails(int index)
        {
            manager.Navigation.OpenHomePage();
            driver.FindElements(By.Name("entry"))[index].FindElements(By.TagName("td"))[6].Click();
            string allDataFromDetailsFormat = Regex.Replace(driver.FindElement(By.Id("content")).Text.Trim(), "[ -():MWH]", "");
            return allDataFromDetailsFormat; 
        }
    }
}
