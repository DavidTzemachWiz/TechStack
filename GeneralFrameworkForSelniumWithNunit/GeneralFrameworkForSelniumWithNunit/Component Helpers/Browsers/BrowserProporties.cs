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
namespace GeneralFrameworkForSelniumWithNunit.Component_Helpers
{
    public class BrowserProporties
    {
        //Return the PageSource
        public static string NevigateToUrl(IWebDriver driver)
        {
            string PageSource = driver.PageSource;
            return PageSource;
        }

        //Return the browser URL
        public static string GetPageUrl(IWebDriver driver)
        {
            string PageUrl = driver.Url;
            return PageUrl;
        }

        //Return the browser URL
        public static string GetPageTitle(IWebDriver driver)
        {
            string PageTitle = driver.Title;
            return PageTitle;
        }
    }
}
