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

namespace E2ETestFramework.Utilities_for_test_Framework
{
    public class BaseClass
    {
        // Will replace this code on all TEST on this project. 
       public IWebDriver driver;

        [SetUp]
        public void StartBrowser()
        {
            //Global Configuration managmant 
            string browsername = ConfigurationManager.AppSettings["browser"];
            initBrowserByType(browsername);//Loaded from configuration file


            driver.Navigate().GoToUrl("https://rahulshettyacademy.com/loginpagePractise/");//hard Coded
            driver.Manage().Window.Maximize();

            //Implicit wait of 5 seconds for all elements 
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
        }

        public void initBrowserByType(string browserType)
        {         
                switch (browserType)
            {
                case "Firefox":
                    new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                    driver = new FirefoxDriver();
                    break;
                case "Edge":
                    new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
                    driver = new EdgeDriver();
                    break;
                case "Chrome":
                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    driver = new ChromeDriver();
                    break;
            }           
        }

        [TearDown]
        public void QuitSssion()
        {
            driver.Quit();
        }
    }
}
