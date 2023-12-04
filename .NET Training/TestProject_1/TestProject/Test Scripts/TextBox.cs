using MStest_TMP.ComponentHelper;
using MStest_TMP.Settings;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStest_TMP.Test_Scripts
{
    [TestClass]
    
    public class TextBox
    {
        [TestMethod]
        public void TestTextBox()
        {
            NevigationHelper.NevigateToSite(ObjectRepository.Config.GetUrl());

            //Full Link Text 
            IWebElement FillABug_1 = ObjectRepository.Driver.FindElement(By.LinkText("File a Bug"));
            FillABug_1.Click();

            //Add credentials from config file
            //ObjectRepository.Driver.FindElement(By.Id("Bugzilla")).SendKeys(ObjectRepository.Config.GetUserName());
            //ObjectRepository.Driver.FindElement(By.Id("Bugzilla_password")).SendKeys(ObjectRepository.Config.GetUserPass());

            TextFieldHelper.TypeInTextBox(By.Id("Bugzilla_login"), ObjectRepository.Config.GetUserName());
            TextFieldHelper.TypeInTextBox(By.Id("Bugzilla_password"), ObjectRepository.Config.GetUserPass());


            Thread.Sleep(3000);
        }
    }
}
