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
    internal class AutoSuggesstion
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
            // Find the input element
            IWebElement inputElement = driver.FindElement(By.Id("autocomplete"));
            inputElement.SendKeys("ind");

            Thread.Sleep(4000);

            //Select an option from the list 
            
            IList<IWebElement> options = driver.FindElements(By.CssSelector(".ui-menu-item div"));
            TestContext.Progress.WriteLine(inputElement.GetAttribute("value"));

            foreach (IWebElement item in options)
            {
                if (item.Text.Equals("India"))
                {
                    item.Click();
                }
            }
        }

        [TearDown]
        public void closeBrowser()
        {
            //driver.Close();
        }

    }
}
