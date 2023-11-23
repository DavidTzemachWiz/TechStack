using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using WebDriverManager.DriverConfigs.Impl;

namespace TestProject1
{
    internal class DropDowns
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
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [Test]
        public void DropDown()
        {
            //Select the Drop-Down Values 
            IWebElement dropdown = driver.FindElement(By.CssSelector("select.form-control"));
            SelectElement choicse = new SelectElement(dropdown);

            //Validate that drop does not allow MultySelction 
            Assert.IsFalse(choicse.IsMultiple);

            //Validate Deault value 
            TestContext.Progress.WriteLine("Default Value selected:" + choicse.SelectedOption.Text);
            Assert.IsTrue(choicse.SelectedOption.Text == "Student");

            //Change value by index (index 0,1 and 2)           
            choicse.SelectByIndex(1); //Change selection by Index
            Assert.IsTrue(choicse.SelectedOption.Text == "Teacher");

            //Changing value by 
            choicse.SelectByValue("consult");
            Assert.IsTrue(choicse.SelectedOption.Text == "Consultant");

            foreach (var item in choicse.Options)
            {
                TestContext.Progress.WriteLine("Item in list: " + item.Text + " | " + item.Selected);
            }
        }

            [TearDown]
        public void CloseBrowser()
        {
            driver.Close();
        }

    }
}
