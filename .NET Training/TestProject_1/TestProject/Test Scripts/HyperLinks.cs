using MStest_TMP.ComponentHelper;
using MStest_TMP.Framework_Configuration;
using MStest_TMP.Settings;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStest_TMP.Test_Scripts
{
    [TestClass]
    public class HyperLinks
    {
        [TestMethod]
        public void ClickLink()
        {
            NevigationHelper.NevigateToSite(ObjectRepository.Config.GetUrl());
           
            //Full Link Text 
            IWebElement FillABug_1 = ObjectRepository.Driver.FindElement(By.LinkText("File a Bug"));
            FillABug_1.Click();

            //Partial Link Text
            //IWebElement FillABug_2 = ObjectRepository.Driver.FindElement(By.LinkText("a Bug"));

            Thread.Sleep(3000);

        }
    }
}
