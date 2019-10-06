using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Education_web_test;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;


namespace addressbook_test_data_generator
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string dataType = args[0];
            int count = Convert.ToInt32(args[1]);
            StreamWriter writer = new StreamWriter(args[2]);
            string format = args[3];
            
            if (dataType == "groups" || dataType == "group")
            {
                GroupDataExpectedFormatCreation(count, writer, format);
            }
            else if (dataType == "contacts" || dataType == "contact")
            {
                ContactDataExpectedFormatCreation(count, writer, format);
            }

            else
            {
                System.Console.Out.Write("Wrong data format" + dataType);
            }

            writer.Close();

        }

        // Data for Contact creation file 
        static void ContactDataExpectedFormatCreation(int count, StreamWriter writer, string format)
        {
            List<ContactData> contacts = new List<ContactData>();

            for (int i = 0; i < count; i++)
            {
                contacts.Add(new ContactData(TestBase.GenerateRandomString(10), TestBase.GenerateRandomString(10), TestBase.GenerateRandomString(10)));
            }
            if (format == "csv")
            {
                WriteContactsToCSVFormat(contacts, writer);
            }

            else if (format == "xml")
            {
                WriteContactsToXMLFormat(contacts, writer);
            }

            else if (format == "json")
            {
                WriteContactsToJSONFormat(contacts, writer);
            }
            else
            {
                System.Console.Out.Write("Wrong data format" + format);
            }
        }


        // Data for Group creation file 
        static void GroupDataExpectedFormatCreation(int count, StreamWriter writer, string format)
        {
            List<GroupData> groups = new List<GroupData>();

            for (int i = 0; i < count; i++)
            {
                groups.Add(new GroupData(TestBase.GenerateRandomString(10), TestBase.GenerateRandomString(10), TestBase.GenerateRandomString(10)));
            }
            if (format == "csv")
            {
                WriteGroupsToCSVFormat(groups, writer);
            }

            else if (format == "xml")
            {
                WriteGroupsToXMLFormat(groups, writer);
            }

            else if (format == "json")
            {
                WriteGroupsToJSONFormat(groups, writer);
            }
            else
            {
                System.Console.Out.Write("Wrong data format" + format);
            }
        }


        // File format creation for Groups
        static void WriteGroupsToCSVFormat(List<GroupData> groups, StreamWriter writer)
        {
            foreach (GroupData group in groups)
            {
                writer.WriteLine(String.Format("${0}, ${1}, ${2}", 
                    group.Name, group.Header, group.Footer));
            }
        }

        static void WriteGroupsToXMLFormat(List <GroupData> groups, StreamWriter writer) 
        {
            new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groups);

        }

        static void WriteGroupsToJSONFormat(List<GroupData> groups, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(groups, Newtonsoft.Json.Formatting.Indented));

        }

        // File format creation for Contacts

        static void WriteContactsToCSVFormat(List<ContactData> contacts, StreamWriter writer)
        {
            foreach (ContactData contact in contacts)
            {
                writer.WriteLine(String.Format("${0}, ${1}, ${2}",
                    contact.Firstname, contact.LastName, contact.Address));
            }
        }

        static void WriteContactsToXMLFormat(List<ContactData> contacts, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<ContactData>)).Serialize(writer, contacts);

        }

        static void WriteContactsToJSONFormat(List<ContactData> contacts, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(contacts, Newtonsoft.Json.Formatting.Indented));

        }
    }
}
