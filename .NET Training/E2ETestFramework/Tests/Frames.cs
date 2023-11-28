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
    internal class Frames:BaseClass
    {       
        [Test]
        public void TestFrame()
        {
            driver.Value.Url = "https://rahulshettyacademy.com/AutomationPractice/";
            //Get the Iframe element
            IWebElement iframe = driver.Value.FindElement(By.Id("courses-iframe"));

            //Scroll down to iframe 
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);",iframe);
            
            //Switch to the frame
            driver.Value.SwitchTo().Frame("courses-iframe");

            Thread.Sleep(3000);
            //Now we can click the button
            driver.Value.FindElement(By.ClassName("new-navbar-highlighter")).Click();

            //If we want to set the driver to the main page we will use: 
            driver.Value.SwitchTo().DefaultContent();
            driver.Value.FindElement(By.ClassName("h1")).Click();

        }

        [TearDown]
        public void closeBrowser()
        {
            //driver.Close();
        }

    }
}
