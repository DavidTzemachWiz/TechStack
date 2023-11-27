using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E2ETestFramework.Utilities_for_test_Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using WebDriverManager.DriverConfigs.Impl;

namespace TestProject1
{
    internal class RadioButton:BaseClass
    {
        [Test]
        public void RadioButton_test()
        {
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";
            IList <IWebElement> rdos = driver.FindElements(By.CssSelector("input[type='radio']"));//Css selector created manually 
            TestContext.Progress.WriteLine("Item in list [0] " + rdos[0].GetAttribute("value") + "IsSelcted?: " + rdos[0].Selected);//Admin
            TestContext.Progress.WriteLine("Item in list [1] " + rdos[1].GetAttribute("value") + "IsSelcted?: " + rdos[1].Selected);//User

            Assert.IsTrue(rdos[0].GetAttribute("value") == "admin" && rdos[1].GetAttribute("value") == "user");


            foreach (IWebElement radiobutton in rdos)
            {
                if (radiobutton.GetAttribute("value").Equals("user"))
                {
                    radiobutton.Click();
                }
            }
        }

            [TearDown]
        public void CloseBrowser()
        {
            driver.Close();
        }

    }
}
