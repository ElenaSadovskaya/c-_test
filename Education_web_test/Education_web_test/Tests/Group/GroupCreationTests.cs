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
    public class GroupCreationTests : AuthTestBase
    {
        public static IEnumerable<GroupData> RandomGroupDataProvider()
        {
            List<GroupData> groups = new List<GroupData>();
            for (int i = 0; i < 5; i++)
            {
                groups.Add(new GroupData(GenerateRandomString(30))
                {
                    Header = GenerateRandomString(100),
                    Footer = GenerateRandomString(100)
                });
            }
            return groups; 
        }


        public static IEnumerable<GroupData> GroupDataFromFileFromCSV()
        {
            List<GroupData> groups = new List<GroupData>();
            string[] lines = File.ReadAllLines(@"groups.csv");
            foreach (string l in lines)
            {
                string[] parts = l.Split(',');
                groups.Add(new GroupData(parts[0], parts[1], parts[2]));
            }
            return groups;
        }

        public static IEnumerable<GroupData> GroupDataFromFileFromXML()
        {
            
            return (List<GroupData>) 
                new XmlSerializer(typeof(List<GroupData>)).Deserialize(new StreamReader(@"groups.xml"));
        }

        public static IEnumerable<GroupData> GroupDataFromFileFromJSON()
        {
           return JsonConvert.DeserializeObject<List<GroupData>>(File.ReadAllText(@"groups.json"));
        }

        [Test, TestCaseSource("GroupDataFromFileFromJSON")]

        public void GroupCreationTest(GroupData group)
        {
            List<GroupData> oldGroups = app.Group.GetGroupList();
            app.Group.Create(group);
            app.Navigation.OpenGroupTab();

            List<GroupData> newGroups = app.Group.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }

    }
}
