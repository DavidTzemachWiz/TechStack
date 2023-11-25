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
    internal class Child_window
    {
        IWebDriver driver;
        String parentWindowHandle;
        String ChildWindowHandle;



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
            parentWindowHandle = driver.CurrentWindowHandle;
        }

        [Test]
        public void ChildWindowUsingID ()
        {
            var link = driver.FindElement(By.PartialLinkText("Free Access to InterviewQues/"));

            Actions action = new Actions(driver);
            action.KeyDown(Keys.Control).MoveToElement(link).Click().Perform();
            driver.SwitchTo().Window(driver.WindowHandles[1]);
            Assert.IsTrue(driver.Url == "https://rahulshettyacademy.com/documents-request");
            Thread.Sleep(3000);
            driver.SwitchTo().Window(driver.WindowHandles[0]);
            Assert.IsTrue(driver.Url == "https://rahulshettyacademy.com/AutomationPractice/");
        }

        [Test]
        public void ChildWindowUsingWindowHandle()
        {
            var link = driver.FindElement(By.PartialLinkText("Free Access to InterviewQues/"));

            Actions action = new Actions(driver);
            action.KeyDown(Keys.Control).MoveToElement(link).Click().Perform();
            driver.SwitchTo().Window(driver.WindowHandles[1]);
            Assert.IsTrue(driver.Url == "https://rahulshettyacademy.com/documents-request");
            Thread.Sleep(3000);
            driver.SwitchTo().Window(parentWindowHandle);
            Assert.IsTrue(driver.Url == "https://rahulshettyacademy.com/AutomationPractice/");
        }

    }
    }