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

        public List<ContactData> GetContactList()
        {
            List<ContactData> contact = new List<ContactData>();
            manager.Navigation.OpenContacts();
            ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("tr"));
            foreach (IWebElement element in elements)
            {
                IList<IWebElement> cells = element.FindElements(By.TagName("td"));

                if (cells.Count != 0)
                {
                    contact.Add(new ContactData(cells[2].Text, cells[1].Text, cells[3].Text));
                }        
            }
            return contact;
        }
    }
}
