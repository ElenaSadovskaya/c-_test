using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education_web_test
{
   public  class ContactData
    {
        private string firstname;
        private string middlename = "";
        private string lastname;
        private string nickname = "";
        private string title = "";
        private string company = "";
        private string address;
        private string home = "";
        private string mobile = "";
        private string work = "";
        private string fax = "";
        private string email = "";
        private string email12 = "";
        private string email13 = "";
        private string homepage = "";
        private string address2 = "";
        private string phone2 = "";
        private string notes = "";
      
        public ContactData(string firstname, string lastname, string address)
        {

            this.firstname = firstname;
            this.lastname = lastname;
            this.address = address;

        }


        public ContactData(string firstname, string lastname, string address, string middlename, string nickname, string title, string company, string home, string mobile, string work, string fax, string email, string email12, string email13, string homepage, string address2, string phone2, string notes )
        {

            this.firstname = firstname ;
            this.middlename =middlename;
            this.lastname = lastname;
            this.nickname = nickname;
            this.title = title;
            this.company = company;
            this.address = address;
            this.home = home;
            this.mobile = mobile;
            this.work = work;;
            this.fax = fax;
            this.email = email;
            this.email12 = email12;
            this.email13 = email13;
            this.homepage = homepage;
            this.address2 = address2;
            this.phone2 = phone2;
            this.notes = notes;

        }

        public string Firstname
        {
            get
            {
                return firstname;
            }

            set
            {
                firstname = value;
            }
        }

        public string Middlename
        {
            get
            {
                return middlename;
            }

            set
            {
                middlename = value;
            }
        }

        public string LastName
        {
            get
            {
                return lastname;
            }

            set
            {
                lastname = value;
            }

        }

        public string Nickname
        {
            get
            {
                return nickname;
            }

            set
            {
                nickname = value;
            }
        }

        public string Title
        {
            get
            {
                return title;
            }

            set
            {
                title = value;
            }

        }

        public string Company
        {
            get
            {
                return company;
            }

            set
            {
                company = value;
            }
        }

        public string Address
        {
            get
            {
                return address;
            }

            set
            {
                address = value;
            }

        }

        public string Home
        {
            get
            {
                return home;
            }

            set
            {
                home = value;
            }
        }

        public string Mobile
        {
            get
            {
                return mobile;
            }

            set
            {
                mobile = value;
            }
        }

        public string Work
        {
            get
            {
                return work;
            }

            set
            {
                work = value;
            }
        }

        public string Fax
        {
            get
            {
                return fax;
            }

            set
            {
                fax = value;
            }
        }


        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                email = value;
            }
        }

        public string Email12
        {
            get
            {
                return email12;
            }

            set
            {
                email12 = value;
            }
        }

        public string Email13
        {
            get
            {
                return email13;
            }

            set
            {
                email13 = value;
            }
        }


        public string Homepage
        {
            get
            {
                return homepage;
            }

            set
            {
                homepage = value;
            }
        }

        public string Adress2
        {
            get
            {
                return address2;
            }

            set
            {
                address2 = value;
            }
        }

        public string Phone2
        {
            get
            {
                return phone2;
            }

            set
            {
                phone2 = value;
            }
        }

        public string Notes
        {
            get
            {
                return notes;
            }

            set
            {
                notes = value;
            }
        }
    }

}
