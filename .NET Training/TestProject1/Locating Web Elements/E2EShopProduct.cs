﻿using System;
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
    internal class E2EShopProduct
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

            //Add Explisit wait to make sure page is loaded (5S)
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementExists(By.CssSelector(".btn.btn-primary.nav-link")));

            //Now we moved to a new window:https://varonis.udemy.com/course/selenium-webdriver-with-csharp-nunit/learn/lecture/28145106#overview
            Assert.AreEqual("https://rahulshettyacademy.com/angularpractice/shop", driver.Url);

            //Select products using array of predefined products we will add
            string[] Preproducts = { "iphone X", "Blackberry" };

            //Create list of all products using product Tags
            IList<IWebElement> products = driver.FindElements(By.TagName("app-card"));

            foreach (IWebElement item in products)
            {
                //TestContext.Progress.WriteLine(item.FindElement(By.CssSelector(".card-title a")).Text);
                if (Preproducts.Contains(item.FindElement(By.CssSelector(".card-title a")).Text)
)
                {
                    item.FindElement(By.CssSelector(".card-footer button")).Click();
                }
            }

            //Click on Checkout button 
            driver.FindElement(By.CssSelector(".nav-link.btn.btn-primary")).Click();
        }
    }         
    }

