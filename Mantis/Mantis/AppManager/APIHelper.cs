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

        public List<ProjectData> GetAllProjects(AccountData account)
        {
            MantisApi.MantisConnectPortTypeClient client = new MantisApi.MantisConnectPortTypeClient();
            MantisApi.ProjectData[] projectDatas = client.mc_projects_get_user_accessible(account.Name, account.Password);
            List<ProjectData> list = new List<ProjectData>();
            foreach (MantisApi.ProjectData projectData in projectDatas)
            {
                list.Add(new ProjectData
                {
                    Name = projectData.name,
                    Id = projectData.id,
                }) ;
            }
            return list;
        }

        public void CheckProjectExist(AccountData account)
        {
            List<ProjectData> list = GetAllProjects(account);
            if (list.Count == 0)
            {
                ProjectData project = new ProjectData("test");
                AddNewProjectAPI(account, project);
            }

        }

        public void AddNewProjectAPI(AccountData account, ProjectData projectData)
        {
            MantisApi.MantisConnectPortTypeClient client = new MantisApi.MantisConnectPortTypeClient();
            MantisApi.ProjectData project = new MantisApi.ProjectData();
            project.name = projectData.Name;
            client.mc_project_add(account.Name, account.Password, project);
        }
    }
        
}
