using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using SimpleBrowser.WebDriver;
using System.Text.RegularExpressions;

namespace Mantis
{
    public class APIHelper : BaseHelper
    {
       
        public APIHelper(ApplicationManager manager) : base(manager)
        {
        }

        public void CreateNewIssue(AccountData account, ProjectData project, IssueData issueData)
        {
            MantisApi.MantisConnectPortTypeClient client = new MantisApi.MantisConnectPortTypeClient();
            MantisApi.IssueData issue = new MantisApi.IssueData();
            issue.summary = issueData.Summary;
            issue.description = issueData.Description;
            issue.category = issueData.Category;
            issue.project = new MantisApi.ObjectRef();
            issue.project.id = project.Id;
            client.mc_issue_add(account.Name, account.Password, issue);
        }
    }
}
