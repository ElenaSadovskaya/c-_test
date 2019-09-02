using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace Education_web_test
{
    public  class TestBase
    {
        protected ApplicationManager app;
        private bool acceptNextAlert = true;
        
        
        [SetUp]
        public void SetupTest()
        {
            app = new ApplicationManager();         
        }

        [TearDown]
        public void TeardownTest()
        {
            app.Stop();
        }

    }
}
