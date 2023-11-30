using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MStest_TMP.CustomErrors;
using MStest_TMP.Framework_Configuration;
using MStest_TMP.Settings;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using WebDriverManager.DriverConfigs.Impl;

namespace MStest_TMP.Framework_Utilities
{
    [TestClass]
    public class BaseClass
    {
        //Create Browser type for test execution
        private static IWebDriver GetChromeDriver()
        {
            var driver = new ChromeDriver();
            return driver;
        }
        private static IWebDriver GetEdgeDriver()
        {
            var driver = new EdgeDriver();
            return driver;
        }
        private static IWebDriver GetFirefoxDriver()
        {
            var driver = new FirefoxDriver();
            return driver;
        }

        [AssemblyInitialize]
        public static void InitWebDriver(TestContext tc)
        {
            ObjectRepository.Config = new AppConfigReader();
            switch (ObjectRepository.Config.GetBrowser())
            {
                case BrowserType.Edge:
                    ObjectRepository.Driver = GetEdgeDriver();
                    break;
                case BrowserType.Firfox:
                    ObjectRepository.Driver = GetFirefoxDriver();

                    break;
                case BrowserType.Chrome:
                    ObjectRepository.Driver = GetChromeDriver();

                    break;
                default:
                    throw new CustomeConfigErrors("Driver Not found: " + ObjectRepository.Config.GetBrowser().ToString());
                    break;
            }
        }

    }
}
