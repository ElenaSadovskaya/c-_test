using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Mantis.Tests
{
    [TestFixture]

    public class AddNewIssues:TestBase
    {
        [Test]

        public void AddNewIssue()
        {
            AccountData account = new AccountData()
            {

                Name = "administrator",
                Password = "root"
            };
            ProjectData project = new ProjectData()
            {
                Id= "1"
            };
            IssueData issue = new IssueData()
            {
                Summary = "some text",
                Description = "short text",
                Category = "1"
            };
            app.API.CreateNewIssue(account, project, issue);
        }
    }
}
