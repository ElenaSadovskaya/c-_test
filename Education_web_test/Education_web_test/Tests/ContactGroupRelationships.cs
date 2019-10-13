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
using System.Linq;

namespace Education_web_test
{
    public class ContactGroupRelationships : AuthTestBase
    {
        [Test]
        public void TestAddingContactToGroup()
        {
            app.Group.CheckGroupExist();
            app.Contact.CheckContactWithoutGroupExist();
            GroupData group = GroupData.GetAll()[0];
            List<ContactData> oldList = group.GetContacts();
            ContactData contact = ContactData.GetAll().Except(oldList).First();
            

            app.Contact.AddContactToGroup(contact, group);

            List<ContactData> newList = group.GetContacts();
            oldList.Add(contact);
            oldList.Sort();
            newList.Sort();

            Assert.AreEqual(oldList, newList);
        }

        [Test]

        public void TestDeletingContactToGroup()
        {
            app.Group.CheckGroupExist();
            app.Contact.CheckContactExist();
            GroupData group = GroupData.GetAll()[0];
            app.Contact.CheckContactInGroupExist(0, group);
            List<ContactData> oldList = group.GetContacts();
            
            app.Contact.RemoveContactToGroup(0, group);

            List<ContactData> newList = group.GetContacts();
            oldList.RemoveAt(0);
            oldList.Sort();
            newList.Sort();

            Assert.AreEqual(oldList, newList);
        }
    }
}
