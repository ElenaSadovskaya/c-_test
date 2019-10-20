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
    public class RemoveProjectTests : AuthTestBase
    {
        [Test]
        public void RemoveProjectTest()
        {
           // List<ProjectData> oldProject = ProjectData.GetAll();
            ProjectData project = new ProjectData("tegghtst");
            app.Project.RemoveSelectedProject(0);
            //List<ProjectData> newProject = ProjectData.GetAll();
            //oldProject.RemoveAt(0);
           /// oldProject.Sort();
            //newProject.Sort();
           // Assert.AreEqual(oldProject, newProject);
        }
    }
}
