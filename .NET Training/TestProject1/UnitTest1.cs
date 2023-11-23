using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager.DriverConfigs.Impl;

namespace TestProject1
{
    public class Tests
    {
        IWebDriver driver;

       [SetUp]
        public void openChromeBrowser()
        {
           TestContext.Progress.WriteLine("Open New browser for tests");

            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver =  new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.google.com/");
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void Test1()
        {
            TestContext.Progress.WriteLine("page Title is: " + driver.Title);
            TestContext.Progress.WriteLine("page URL is: " + driver.Url);
            Assert.AreEqual(driver.Url, "https://www.google.com/");
            
        }


        [Test]
        public void Test2()
        {
            Assert.Pass();
        }

        [TearDown]
        public void closeBrowser()
        {
            TestContext.Progress.WriteLine("Closing method Execution");
            driver.Quit();

        }
    }
}