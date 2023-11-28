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
    internal class AutoSuggesstion : BaseClass
    {
        [Test]
        public void TestAlert()
        {
            driver.Value.Url = "https://rahulshettyacademy.com/AutomationPractice/";
            // Find the input element
            IWebElement inputElement = driver.Value.FindElement(By.Id("autocomplete"));
            inputElement.SendKeys("ind");

            Thread.Sleep(4000);

            //Select an option from the list 
            
            IList<IWebElement> options = driver.Value.FindElements(By.CssSelector(".ui-menu-item div"));
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
            driver.Value.Close();
        }

    }
}
