using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.IO;

namespace Mantis
{
    [TestFixture]
    public class AddAndRemoveProjectsViaAPI : AuthTestBase
    {
        [Test]
        public void AddNewProjectTest()
        {
            AccountData account = new AccountData()
            {
                Name = "administrator",
                Password = "root"
            };

            List<ProjectData> oldProject = app.API.GetAllProjects(account);
            ProjectData project = new ProjectData("123456");
            app.API.AddNewProjectAPI(account, project);
            List<ProjectData> newProject = app.API.GetAllProjects(account);

            oldProject.Add(project);
            oldProject.Sort();
            newProject.Sort();
            Assert.AreEqual(oldProject, newProject);
        }


        [Test]
        public void RemoveProject()
        {
            AccountData account = new AccountData()
            {
                Name = "administrator",
                Password = "root"
            };

            app.API.CheckProjectExist(account);
            List<ProjectData> oldProject = app.API.GetAllProjects(account);
            app.Project.RemoveSelectedProject(0);
            List<ProjectData> newProject = app.API.GetAllProjects(account);
            oldProject.RemoveAt(0);
            oldProject.Sort();
            newProject.Sort();
            Assert.AreEqual(oldProject, newProject);            
        }


    }
}