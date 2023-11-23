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
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using WebDriverManager.Clients;
using WebDriverManager.DriverConfigs.Impl;

namespace TestProject1.Locating_Web_Elements
{
    internal class JSAlerts
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
        public void TestAlert()
        {
            //Basic Alert Buttonn
            //driver.FindElement(By.Id("alertbtn")).Click();

       

            //Add text  
            driver.FindElement(By.Name("enter-name")).SendKeys("David Tzemach");
            //Conformation Alert button 
            driver.FindElement(By.Id("confirmbtn")).Click();

            //Validate Alert syntax 
            var alertText = driver.SwitchTo().Alert().Text;
            Assert.AreEqual("Hello David Tzemach, Are you sure you want to confirm?", alertText);

            driver.SwitchTo().Alert().Accept();

            //More commands 
            //driver.SwitchTo().Alert().SendKeys("");
            // driver.SwitchTo().Alert().Dismiss();
        }

        [TearDown]  
        public void closeBrowser()
        {
            driver.Close();
        }

    }
}
