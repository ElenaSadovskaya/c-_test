using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB;


namespace Mantis
{
    public class AddressbookDB : LinqToDB.Data.DataConnection
    {
        public AddressbookDB() : base("bugtracker")
        {

        }

        public ITable<ProjectData> Projects { get { return GetTable<ProjectData>(); } }

        

    }
}
