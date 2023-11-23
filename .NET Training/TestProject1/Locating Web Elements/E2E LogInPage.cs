using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V117.Runtime;
using OpenQA.Selenium.Support.UI;
using WebDriverManager.DriverConfigs.Impl;

namespace TestProject1.Locating_Web_Elements
{
    internal class E2E_LogInPage
    {
        IWebDriver driver;

        [SetUp]
        public void openChromeBrowser()
        {
            //TestContext.Progress.WriteLine("Open New browser for tests");
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://rahulshettyacademy.com/loginpagePractise/");
            driver.Manage().Window.Maximize();

            //Implicit wait of 5 seconds for all elements 
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
        }

        [Test]
        public void FillAllInformation()
        {
            //Enter user name and password 
            driver.FindElement(By.Id("username")).SendKeys("rahulshettyacademy");
            driver.FindElement(By.Id("password")).SendKeys("learning");

            //Select Consultant in drop down
            IWebElement dropdown = driver.FindElement(By.CssSelector("select.form-control"));
            SelectElement choicse = new SelectElement(dropdown);
            choicse.SelectByValue("consult");

            //Click Sign-in button
            driver.FindElement(By.Id("signInBtn")).Click();

            //Now we moved to a new window:https://varonis.udemy.com/course/selenium-webdriver-with-csharp-nunit/learn/lecture/28145106#overview
            Assert.AreEqual("https://rahulshettyacademy.com/loginpagePractise/", driver.Url);
           
        }
    }
}
