using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E2ETestFramework.POM_Classes;
using E2ETestFramework.Utilities_for_test_Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V117.Runtime;
using OpenQA.Selenium.Support.UI;
using WebDriverManager.DriverConfigs.Impl;

namespace TestProject1.Locating_Web_Elements
{
    internal class E2E_LogInPage:BaseClass
    {
        [Test]
        public void FillAllInformation()
        {
            //Enter user name and password 
            log_In_Page log_In_Page = new log_In_Page(driver);//Driver is from BASE class! 

            log_In_Page.getUserName().SendKeys("rahulshettyacademy");
            log_In_Page.getPassword().SendKeys("learning");

            //Select Consultant in drop down
            IWebElement dropdown = log_In_Page.getdropdown();
            SelectElement choicse = new SelectElement(dropdown);
            choicse.SelectByValue("consult");

            //Click Sign-in button
            log_In_Page.getSignInBtn().Click();
           
            //Now we moved to a new window:https://varonis.udemy.com/course/selenium-webdriver-with-csharp-nunit/learn/lecture/28145106#overview
            Assert.AreEqual("https://rahulshettyacademy.com/loginpagePractise/", driver.Url);    
        }
    }
}
