﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB.Mapping;

namespace Education_web_test
{
    [Table(Name = "group_list")]
    public class GroupData : IEquatable<GroupData>, IComparable<GroupData>
    {

        public GroupData()
        {

        }

        public GroupData(string name)
        {
            Name = name;

        }

        public bool Equals(GroupData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return Name == other.Name;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }


        public override string ToString()
        {
            return "name = " + Name + "\nheader =" + Header + "\nfooter = " + Footer;
        }

        public int CompareTo(GroupData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return Name.CompareTo(other.Name);
        }

        public GroupData(string name, string header, string footer)
        {
            Name = name;
            Header = header;
            Footer = footer;
        }

        [Column(Name = "group_name")]

        public string Name { get; set; }

        [Column(Name = "group_header")]
        public string Header { get; set; }

        [Column(Name = "group_footer")]
        public string Footer { get; set; }
        [Column(Name = "group_id"), PrimaryKey, Identity]
        public string Id { get; set; }

        public static List<GroupData> GetAll()
        {
            using (AddressbookDB dB = new AddressbookDB())
            {
                return (from g in dB.Groups select g).ToList();
            }
        }

        public List<ContactData> GetContacts()
        {
            using (AddressbookDB dB = new AddressbookDB())
            {
                return (from c in dB.Contacts

                        from grc in dB.GCR.Where(p=> p.GroupId == Id&& p.ContactId == c.Id&& c.Deprecated == "0000-00-00 00:00:00")
                        select c).Distinct().ToList();
            }
        }
    }
}