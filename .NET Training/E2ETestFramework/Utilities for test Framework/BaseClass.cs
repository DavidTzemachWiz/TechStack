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


namespace E2ETestFramework.Utilities_for_test_Framework
{
    public class BaseClass
    {
        string browsername;

        //Configure reports
        [OneTimeSetUp]//will run only once for all test 
        public void Setup()
        {
            string workingDirecory = Environment.CurrentDirectory;
            string projctDirectory = Directory.GetParent(workingDirecory).Parent.Parent.FullName;
            var htmreporter = new ExtentHtmlReporter();
        }
     
       public ThreadLocal<IWebDriver> driver = new ThreadLocal<IWebDriver>();

        [SetUp]// Will run prior each test 
        public void StartBrowser()
        {
            //Global Configuration managmant 
            //First we check if it got the value from the terminal, if YEs it will use it
            //IF NOT he will use the data from the configuration file
            browsername= TestContext.Parameters["browsername"];
            if (browsername == null)
            {
                browsername = ConfigurationManager.AppSettings["browser"];
            }

            
            initBrowserByType(browsername);//Loaded from configuration file


            driver.Value.Navigate().GoToUrl("https://rahulshettyacademy.com/loginpagePractise/");//hard Coded
            driver.Value.Manage().Window.Maximize();

            //Implicit wait of 5 seconds for all elements 
            driver.Value.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
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
            driver.Value.Quit();
        }
    }
}
