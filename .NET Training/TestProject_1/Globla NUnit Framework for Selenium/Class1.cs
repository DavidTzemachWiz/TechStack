
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Globla_NUnit_Framework_for_Selenium.Framework_Global
{
    public class Class1:BaseClass
    {
        [Test]
        public void TestFrame()
        {
            var link = driver.Value.FindElement(By.PartialLinkText("Free Access to InterviewQues/"));
         
        }
    }
}
