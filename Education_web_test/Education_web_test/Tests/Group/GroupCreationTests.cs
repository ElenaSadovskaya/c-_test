﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace Education_web_test
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {
        [Test]

        public void GroupCreationTest()
        {
            GroupData group = new GroupData("123");
            
            app.Group.Create(group);
            app.Navigation.OpenGroupTab();
            

        }

    }
}
