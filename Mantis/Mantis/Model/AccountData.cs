﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mantis
{
    public class AccountData
    {

        public AccountData()
        {
           
        }
        public AccountData(string name, string password)
        {
            Name = name;
            Password = password;
        }

        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
