using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E2ETestFramework.Utilities_for_test_Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V117.HeadlessExperimental;
using OpenQA.Selenium.DevTools.V117.Runtime;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using WebDriverManager.Clients;
using WebDriverManager.DriverConfigs.Impl;

namespace TestProject1.Locating_Web_Elements
{
    internal class JSAlerts:BaseClass
    {
       
        [Test]
        public void TestAlert()
        {
            driver.Value.Url = "https://rahulshettyacademy.com/AutomationPractice/";
            driver.Value.Manage().Window.Maximize();

            //Basic Alert Buttonn
            //driver.FindElement(By.Id("alertbtn")).Click();

            //Add text  
            driver.Value.FindElement(By.Name("enter-name")).SendKeys("David Tzemach");
            //Conformation Alert button 
            driver.Value.FindElement(By.Id("confirmbtn")).Click();

            //Validate Alert syntax 
            var alertText = driver.Value.SwitchTo().Alert().Text;
            Assert.AreEqual("Hello David Tzemach, Are you sure you want to confirm?", alertText);

            driver.Value.SwitchTo().Alert().Accept();

            //More commands 
            //driver.SwitchTo().Alert().SendKeys("");
            // driver.SwitchTo().Alert().Dismiss();
        }

        [Test]
        public void test_actions()
        {
            //Change URL for this tests
            driver.Value.Url = "https://rahulshettyacademy.com/";

            //Actions 
            Actions a = new Actions(driver.Value);
            a.MoveToElement(driver.Value.FindElement(By.CssSelector("a.dropdown-toggle"))).Perform();
            a.MoveToElement(driver.Value.FindElement(By.XPath("//ul[@class='dropdown-menu']/li[1]/a"))).Click().Perform();
            Thread.Sleep(3000);

        }

        [TearDown]  
        public void closeBrowser()
        {
            driver.Value.Close();
        }

    }
}
