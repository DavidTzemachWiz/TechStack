using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using GeneralFrameworkForSelniumWithNunit.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using WebDriverManager.DriverConfigs.Impl;

namespace GeneralFrameworkForSelniumWithNunit.TestHelpers
{
    public class BrowserCommands
    {       

        //We will use this Command if we want to test diffent site than what we have in the configuration file
        public static void NevigateToUrl(IWebDriver driver ,string url)
        {
           driver.Navigate().GoToUrl(url);  
        }

        //Refresh Site
        public static void RefreshSite(IWebDriver driver)
        {
            driver.Navigate().Refresh();
        }

        //Back Command 
        public static void BackToPreviousPage(IWebDriver driver)
        {
            driver.Navigate().Back();
        }

        //Forward Command
        public static void ForwardToNextPage(IWebDriver driver)
        {
            driver.Navigate().Forward();
        }

        //Maximize Page
        public static void MaxPage(IWebDriver driver)
        {
            driver.Manage().Window.Maximize();
        }

        //Minimize Page
        public static void MinPage(IWebDriver driver)
        {
            driver.Manage().Window.Minimize();
        }

        //Close Session
        public static void Close(IWebDriver driver)
        {
            driver.Close();
        }

        //Quit 
        public static void Quit(IWebDriver driver)
        {
            driver.Quit();
        }
    }
}
