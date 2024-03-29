﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using Newtonsoft.Json;
using LinqToDB.Mapping;

namespace Education_web_test
{
    [Table(Name = "addressbook")]
    public  class ContactData: IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhone;
        private string allEmail;

        public ContactData()
        {
        }

        public ContactData(string firstname, string lastname, string address)
        {

            Firstname = firstname;
            LastName = lastname;
            Address = address;

        }
        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return (LastName == other.LastName)&((Firstname == other.Firstname)&(Address == other.Address));
        }

        public override int GetHashCode()
        {
            return Firstname.GetHashCode() & LastName.GetHashCode() & Address.GetHashCode();
        }

        public override string ToString()
        {
            return "LastName=" + LastName + "FirstName=" + Firstname + "Address=" + Address;
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                
                    return 1;
            }

            if (LastName.CompareTo(other.LastName) == 0)
            {
                return Firstname.CompareTo(other.Firstname);
            }
            else
            {
                return LastName.CompareTo(other.LastName);
            }            
        }

        

        public ContactData(string firstname, string lastname, string address, string middlename, string nickname, string title, string company, string home, string mobile, string work, string fax, string email, string email2, string email3, string homepage, string address2, string phone2, string notes )
        {

            
            Firstname = firstname ;
            Middlename =middlename;
            LastName = lastname;
            Nickname = nickname;
            Title = title;
            Company = company;
            Address = address;
            Home = home;
            Mobile = mobile;
            Work = work;;
            Fax = fax;
            Email = email;
            Email2 = email2;
            Email3 = email3;
            Homepage = homepage;
            Address2 = address2;
            Phone2 = phone2;
            Notes = notes;

        }
        [Column(Name = "firstname")]
        public string Firstname { get; set; }
        [Column(Name = "middlename")]
        public string Middlename { get; set; }
        [Column(Name = "lastname")]
        public string LastName { get; set; }
        public string Nickname { get; set; }
        public string Title { get; set; }
        public string Company { get; set; }
        [Column(Name = "address")]
        public string Address { get; set; }
        [Column(Name = "home")]
        public string Home { get; set; }
        [Column(Name = "mobile")]
        public string Mobile { get; set; }
        [Column(Name = "work")]
        public string Work { get; set; }
        public string Fax { get; set; }
        [Column(Name = "email")]
        public string Email { get; set; }
        [Column(Name = "email2")]
        public string Email2 { get; set; }
        [Column(Name = "email3")]
        public string Email3 { get; set; }
        public string Homepage { get; set; }
        public string Address2 { get; set; }
        public string Phone2 { get; set; }
        public string Notes { get; set; }
        [Column(Name = "id"), PrimaryKey, Identity]
        public string Id { get; set; }
        [Column(Name = "deprecated")]
        public string Deprecated { get; set; }

        public string HomeCheck(string homePhone)
        {
            if (homePhone == null || homePhone == "")
            {
                return homePhone;
            }
            else
            {

                return homePhone.Insert(0, "H: ");
            }
        }

        public string MobileCheck(string mobilePhone)
        {
            if (mobilePhone == null || mobilePhone == "")
            {
                return mobilePhone;
            }
            else
            {

                return mobilePhone.Insert(0, "M: ");
            }
        }

        public string WorkCheck(string workPhone)
        {
            if (workPhone == null || workPhone == "")
            {
                return workPhone;
            }
            else
            {

                return workPhone.Insert(0, "W: ");
            }
        }

        [XmlIgnore, JsonIgnore]

        public string AllPhone
        {
            get
            {
                if (allPhone != null)
                {
                    return allPhone;
                }
                else
                {               
                    
                    return ( CleanUpPhone(HomeCheck(Home)) + CleanUpPhone(MobileCheck(Mobile)) + CleanUpPhone(WorkCheck(Work))).Trim(); 
                }
            }
            
            set
            {
                allPhone = value;
            }
        }


        [XmlIgnore, JsonIgnore]

        public string AllEmail
        {
            get
            {
                if (allEmail != null)
                {
                    return allEmail;
                }
                else
                {
                    return (CleanUpEmail(Email) + CleanUpEmail(Email2) + CleanUpEmail(Email3)).Trim();
                }
            }

            set
            {
                allEmail = value;
            }
        }

        private string CleanUpPhone(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return Regex.Replace(phone, "[-()]", "")  + "\r\n";
        }


        private string CleanUpEmail(string email)
        {
            if (email == null || email == "")
            {
                return "";
            }
            return Regex.Replace(email, "[ -()]", "") + "\r\n";
        }

        private string CleanUpAddress(string address)
        {
            if ( address== null || address == "")
            {
                return "";
            }
            return address + "\r\n";
        }


        [XmlIgnore, JsonIgnore]
        public string AllData
        {
            get
            {
                
                return ((Firstname + " " +  LastName + "\r\n") + CleanUpAddress(Address) + "\r\n" + (AllPhone + "\r\n") + "\r\n" + (AllEmail + "\r\n")).Trim();

            }

            set
            {
                AllData = value;
            }
        }

        public static List<ContactData> GetAll()
        {
            using (AddressbookDB dB = new AddressbookDB())
            {
                return (from c in dB.Contacts.Where(c=> c.Deprecated == "0000-00-00 00:00:00") select c).ToList();
            }
        }
    }

}
