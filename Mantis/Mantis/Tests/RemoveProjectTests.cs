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
            app.Project.CheckProjectExist();
            List<ProjectData> oldProject = ProjectData.GetAll();
            ProjectData toBeRemoved = oldProject[0];
            app.Project.RemoveSelectedProject(toBeRemoved);
            List<ProjectData> newProject = ProjectData.GetAll();
            oldProject.RemoveAt(0); 
            oldProject.Sort();
            newProject.Sort();
            Assert.AreEqual(oldProject, newProject);
            foreach (ProjectData project in newProject)
            {
                Assert.AreNotEqual(project.Id, toBeRemoved.Id);
            }
        }
    }
}
