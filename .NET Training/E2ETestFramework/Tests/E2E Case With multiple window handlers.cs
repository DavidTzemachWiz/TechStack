﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E2ETestFramework.Utilities_for_test_Framework;
using NUnit.Framework.Internal;
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
    internal class E2E_Case_With_multiple_window_handlers:BaseClass
    {
       
        [Test]
        public void WindowHandler_1()
        {
            driver.Value.Url = "https://rahulshettyacademy.com/AutomationPractice/";
            string parentWindow;
            string childWindow ;
            //part 1 -> Access and open a link in a new TAB
            var link = driver.Value.FindElement(By.PartialLinkText("Free Access to InterviewQues/"));
            Actions action = new Actions(driver.Value);
            action.KeyDown(Keys.Control).MoveToElement(link).Click().Perform();

            parentWindow = driver.Value.WindowHandles[0];
            childWindow = driver.Value.WindowHandles[1];

            //part 2 - > Validate two windows
            Assert.AreEqual(2, driver.Value.WindowHandles.Count);

            //Part 3 - > Move to the new window and bacl
            driver.Value.SwitchTo().Window(childWindow);
            Assert.IsTrue(driver.Value.Url == "https://rahulshettyacademy.com/documents-request");
            Thread.Sleep(3000);

            driver.Value.SwitchTo().Window(parentWindow);
            Assert.IsTrue(driver.Value.Url == "https://rahulshettyacademy.com/AutomationPractice/");
            
        }
       
            
        }

    }

