using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using System.Linq.Expressions;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using AngleSharp;
using System.Configuration;
using System.Threading;
using OpenQA.Selenium.DevTools.V117.Page;
using System.CodeDom;
using static System.Net.Mime.MediaTypeNames;
using AventStack.ExtentReports.Configuration;

namespace General_Test_Framework_for_UI_automation.Utilities
{
    public class BaseClass
    {
        string browsername;
        //Set driver.value for so we can run tests in parrallel

        public ThreadLocal<IWebDriver> driver = new ThreadLocal<IWebDriver>();

        [TestInitialize] // Will run prior each test 
        public void StartBrowser()
        {

            browsername = TestContext.Parameters["browsername"];
            if (browsername == null)
            {
                browsername = ConfigurationManager.AppSettings["browser"];
            }


        }
    }
}
