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
    internal class Child_window:BaseClass
    {
        
        String parentWindowHandle;
        String ChildWindowHandle;

        [Test]
        public void ChildWindowUsingID ()
        {
            driver.Value.Url = "https://rahulshettyacademy.com/AutomationPractice/";
            var link = driver.Value.FindElement(By.PartialLinkText("Free Access to InterviewQues/"));

            Actions action = new Actions(driver.Value);
            action.KeyDown(Keys.Control).MoveToElement(link).Click().Perform();
            driver.Value.SwitchTo().Window(driver.Value.WindowHandles[1]);
            Assert.IsTrue(driver.Value.Url == "https://rahulshettyacademy.com/documents-request");
            Thread.Sleep(3000);
            driver.Value.SwitchTo().Window(driver.Value.WindowHandles[0]);
            Assert.IsTrue(driver.Value.Url == "https://rahulshettyacademy.com/AutomationPractice/");
        }

        [Test]
        public void ChildWindowUsingWindowHandle()
        {
            var link = driver.Value.FindElement(By.PartialLinkText("Free Access to InterviewQues/"));

            Actions action = new Actions(driver.Value);
            action.KeyDown(Keys.Control).MoveToElement(link).Click().Perform();
            driver.Value.SwitchTo().Window(driver.Value.WindowHandles[1]);
            Assert.IsTrue(driver.Value.Url == "https://rahulshettyacademy.com/documents-request");
            Thread.Sleep(3000);
            driver.Value.SwitchTo().Window(parentWindowHandle);
            Assert.IsTrue(driver.Value.Url == "https://rahulshettyacademy.com/AutomationPractice/");
        }

    }
    }