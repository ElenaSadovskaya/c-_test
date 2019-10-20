using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;


namespace Mantis
{
    public class ProjectManagementHelper: BaseHelper
    {
        public ProjectManagementHelper(ApplicationManager manager) : base(manager)
        {

        }

        public void AddNewProject(ProjectData project)
        {
            manager.Navigation.OpenProjectPage();
            AddNewProjectButton();
            FillData(project);
            SubmitNewProjectCreation();
        }

        public  void RemoveSelectedProject(int v)
        {
            manager.Navigation.OpenProjectPage();
            SelectProject(v);
            PressRemoveButton();

        }

        public void PressRemoveButton()
        {
            driver.FindElement(By.XPath("//input[@value='Delete Project']")).Click();
        }

        public void SelectProject(int v)
        {
            driver.FindElements(By.TagName("tbody"))[0].FindElements(By.CssSelector("tr"))[v].FindElements(By.TagName("td"))[0].Click();
        }

        public void AddNewProjectButton()
        {
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();
        }

        public void SubmitNewProjectCreation ()
        {
            driver.FindElement(By.XPath("//input[@value='Add Project']")).Click();
        }

        public void FillData(ProjectData project)
        {
            Type(By.Name("name"), project.Name);
        }
    }
}
