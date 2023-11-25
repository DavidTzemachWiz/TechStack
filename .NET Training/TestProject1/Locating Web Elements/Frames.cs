using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    internal class Frames
    {
        IWebDriver driver;

        [SetUp]
        public void openChromeBrowser()
        {
            //TestContext.Progress.WriteLine("Open New browser for tests");
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://rahulshettyacademy.com/AutomationPractice/");
            driver.Manage().Window.Maximize();

            //Implicit wait of 5 seconds for all elements 
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
        }

        [Test]
        public void TestFrame()
        {
            //Get the Iframe element
            IWebElement iframe = driver.FindElement(By.Id("courses-iframe"));

            //Scroll down to iframe 
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);",iframe);
            
            //Switch to the frame
            driver.SwitchTo().Frame("courses-iframe");

            Thread.Sleep(3000);
            //Now we can click the button
            driver.FindElement(By.ClassName("new-navbar-highlighter")).Click();

            //If we want to set the driver to the main page we will use: 
            driver.SwitchTo().DefaultContent();
            driver.FindElement(By.ClassName("h1")).Click();

        }

        [TearDown]
        public void closeBrowser()
        {
            //driver.Close();
        }

    }
}
