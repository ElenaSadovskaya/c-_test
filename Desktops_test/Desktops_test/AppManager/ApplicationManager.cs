﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoItX3Lib;

namespace Desktops_test
{
    public class ApplicationManager
    {
        public static string WINTITLE = "Free Address Book";
        public AutoItX3 aux;
        public GroupHelper groupHelper;

        public ApplicationManager()
        {
            aux = new AutoItX3();
            aux.Run(@"C:\Program Files (x86)\GAS Softwares\Free Address Book\AddressBook.exe","", aux.SW_SHOW);
            aux.WinWait(WINTITLE);
            aux.WinActivate(WINTITLE);
            aux.WinWaitActive(WINTITLE);
            groupHelper = new GroupHelper(this);
        }

        public AutoItX3 Aux
        {
            get
            {
                return aux;
            }
        }

        public void Stop()
        {
            aux.ControlClick(WINTITLE, "", "WindowsForms10.BUTTON.app.0.1114f8110");
        }

        public GroupHelper Groups
        {
            get
            {
                return groupHelper;
            }
        }

    }

    
}
