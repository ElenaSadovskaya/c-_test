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
    public class AddNewProjectTests : AuthTestBase
    {
        [Test]
        public void AddNewProjectTest()
        {
            List<ProjectData> oldProject = ProjectData.GetAll();
            ProjectData  project = new ProjectData("tegghtst");
            app.Project.AddNewProject(project);
            List<ProjectData> newProject = ProjectData.GetAll();

            oldProject.Add(project);
            oldProject.Sort();
            newProject.Sort();
            Assert.AreEqual(oldProject, newProject);
        }

        [Test]

        public void TestDBConnection()
        {
            foreach (ProjectData project in ProjectData.GetAll())
            {
                System.Console.Out.WriteLine(project);
            }

        }
    }
}
