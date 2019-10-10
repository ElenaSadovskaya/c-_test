using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Education_web_test
{
    [TestFixture]
    class ContactCreationTests : ContactTestBest
    {
        public static IEnumerable<ContactData> RandomContactDataProvider()
        {
            List<ContactData> contact = new List<ContactData>();
            for (int i = 0; i < 5; i++)
            {
                contact.Add(new ContactData(GenerateRandomString(30), GenerateRandomString(30), GenerateRandomString(30))
                {
                    Firstname = GenerateRandomString(100),
                    LastName = GenerateRandomString(100),
                    Address = GenerateRandomString(100)
                });
            }
            return contact;
        }

        public static IEnumerable<ContactData> ContactDataFromFileFromCSV()
        {
            List<ContactData> contacts = new List<ContactData>();
            string[] lines = File.ReadAllLines(@"contacts.csv");
            foreach (string l in lines)
            {
                string[] parts = l.Split(',');
                contacts.Add(new ContactData(parts[0], parts[1], parts[2]));
            }
            return contacts;
        }

        public static IEnumerable<ContactData> ContactDataFromFileFromXML()
        {

            return (List<ContactData>)
                new XmlSerializer(typeof(List<ContactData>)).Deserialize(new StreamReader(@"contacts.xml"));
        }

        public static IEnumerable<ContactData> ContactDataFromFileFromJSON()
        {
            return JsonConvert.DeserializeObject<List<ContactData>>(File.ReadAllText(@"contacts.json"));
        }

        [Test, TestCaseSource("ContactDataFromFileFromJSON")]

        public void ContactCreation(ContactData contact)
        {
            List<ContactData> oldContact = ContactData.GetAll();
            app.Contact.Create(contact);
            app.Navigation.OpenContacts();
            List<ContactData> newContact = ContactData.GetAll();
            oldContact.Add(contact);
            oldContact.Sort();
            newContact.Sort();
            Assert.AreEqual(oldContact, newContact);
        }

        
    }
}
