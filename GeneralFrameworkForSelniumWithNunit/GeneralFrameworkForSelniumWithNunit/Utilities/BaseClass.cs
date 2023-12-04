using AventStack.ExtentReports;
using AventStack.ExtentReports.Configuration;
using AventStack.ExtentReports.Reporter;
using GeneralFrameworkForSelniumWithNunit.Component_Helpers;
using GeneralFrameworkForSelniumWithNunit.TestHelpers;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using WebDriverManager.DriverConfigs.Impl;

namespace GeneralFrameworkForSelniumWithNunit.Utilities
{
    public class BaseClass
    {
        public string browsername;
        //Configure reports
        public ExtentReports extent;
        public ExtentTest test;

        [OneTimeSetUp]//will run only once for all test 
        public void Setup()
        {
            string workingDirecory = Environment.CurrentDirectory;
            string projctDirectory = Directory.GetParent(workingDirecory).Parent.Parent.FullName;
            string reportPath = projctDirectory + "//index.html";
            var htmReporter = new ExtentHtmlReporter(reportPath);
            extent = new ExtentReports();
            extent.AttachReporter(htmReporter);
            extent.AddSystemInfo("Env", "QA");
            extent.AddSystemInfo("Env", "Dev");
        }
        //Create thread for PParrallel Test run 
        public ThreadLocal<IWebDriver> driver = new ThreadLocal<IWebDriver>();

        [SetUp]// Will run prior each test 
        public void StartBrowser()
        {
            //Create report
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);

            //Step 1: Check if CLI share browser parameter. if YES we will use it
            browsername = TestContext.Parameters["browsername"];

            if (browsername == null)
            {
                //Step 2: We will use the Browser data from the App.config file
                browsername = System.Configuration.ConfigurationManager.AppSettings["browser"];
            }

            initBrowserByType(browsername);//Loaded from configuration file

            //Option_1: hard Coded
            //driver.Value.Navigate().GoToUrl("https://rahulshettyacademy.com/loginpagePractise/");
            //driver.Value.Manage().Window.Maximize();

            //Option_2: BrowserCommand Class 
            BrowserCommands.NevigateToUrl(driver.Value, System.Configuration.ConfigurationManager.AppSettings["TestSite"]);
            BrowserCommands.MaxPage(driver.Value);

            //Implicit wait of 5 seconds for all elements 
            WaitHelpers.ImplicitWait(driver.Value, 5);


            //driver.Value.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
        }

        public void initBrowserByType(string browserType)
        {
            switch (browserType)
            {
                case "Firefox":
                    new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                    driver.Value = new FirefoxDriver();
                    break;
                case "Edge":
                    new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
                    driver.Value = new EdgeDriver();
                    break;
                case "Chrome":
                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    driver.Value = new ChromeDriver();
                    break;
            }
        }
        [TearDown]
        public void QuitSssion()
        {
            //Publish test results
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stackTrace = TestContext.CurrentContext.Result.StackTrace;

            DateTime time = DateTime.Now;
            string fileName = "ScreenShot-" + time.ToString("h_mm_ss") + ".png";
            if (status == TestStatus.Failed)
            {
                test.Fail("Test Fail", CaptureScreenshot(driver.Value, fileName));
                test.Log(Status.Fail, "Test Fail with log trace" + stackTrace);
            }
            else if (status == TestStatus.Passed)
            {

            }
            extent.Flush();
            BrowserCommands.Quit(driver.Value);         
        }

        public MediaEntityModelProvider CaptureScreenshot(IWebDriver driver, string screenShotName)
        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            var screenshot = ts.GetScreenshot().AsBase64EncodedString;
            return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot, screenShotName).Build();
        }

    }
}
