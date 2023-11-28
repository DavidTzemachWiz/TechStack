using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E2ETestFramework.DesignPattern___PageObjects;
using E2ETestFramework.POM_Classes;
using E2ETestFramework.Utilities_for_test_Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V117.HeadlessExperimental;
using OpenQA.Selenium.DevTools.V117.Runtime;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using WebDriverManager.Clients;
using WebDriverManager.DriverConfigs.Impl;

namespace TestProject1.Locating_Web_Elements
{
    internal class E2EShopProduct : BaseClass
    {
        static jsonHelper jsonData = new jsonHelper();

        [Test, TestCaseSource("AddTestDataConfig")]

        public void FillAllInformation(string username, string password, string[] pr)
        {
            
            //Enter user name and password 
            log_In_Page log_In_Page = new log_In_Page(driver.Value);//Driver is from BASE class! 
            //Before:
            //log_In_Page.getUserName().SendKeys("rahulshettyacademy");
            //log_In_Page.getPassword().SendKeys("learning");

            //After
            log_In_Page.User_and_Pass(username,password);

            //Select Consultant in drop down
            IWebElement dropdown = log_In_Page.getdropdown();
            SelectElement choicse = new SelectElement(dropdown);
            choicse.SelectByValue("consult");

              //Click Sign-in button
            log_In_Page.getSignInBtn().Click();

            //Page Object of ProductPage
            ProductPage ProductsPurchese = new ProductPage(driver.Value);
            //Add Explisit wait to make sure page is loaded (5S)
            ProductsPurchese.WaitForPageDisplay(5);

            //Will replace this code:
            //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            //wait.Until(ExpectedConditions.ElementExists(By.CssSelector(".btn.btn-primary.nav-link")));

            //Now we moved to a new window:https://varonis.udemy.com/course/selenium-webdriver-with-csharp-nunit/learn/lecture/28145106#overview
            Assert.AreEqual("https://rahulshettyacademy.com/angularpractice/shop", driver.Value.Url);

            //Select products using array of predefined products we will add
            string[] Preproducts = pr;

            //Create list of all products using product Tags
            //Before: IList<IWebElement> products = driver.FindElements(By.TagName("app-card"));
            //After:
            IList<IWebElement> products = ProductsPurchese.getAppCard();

            foreach (IWebElement item in products)
            {
                //TestContext.Progress.WriteLine(item.FindElement(By.CssSelector(".card-title a")).Text);
                if (Preproducts.Contains(item.FindElement(By.CssSelector(".card-title a")).Text)
)
                {
                    item.FindElement(By.CssSelector(".card-footer button")).Click();
                }
            }

            //Click on Checkout button 
            driver.Value.FindElement(By.CssSelector(".nav-link.btn.btn-primary")).Click();


            //Validatet that the correct products are in cart
            IList<IWebElement> productsInCart = driver.Value.FindElements(By.CssSelector("h4 a"));

            bool verification = false;
            foreach (var item in productsInCart)
            {
                if (item.Text == "iphone X" || item.Text == "Blackberry")
                {
                    TestContext.Progress.WriteLine(item.Text);
                    verification = true;
                }
                else { verification = false; }
            }
            if (verification == true)
            {
                Assert.IsTrue(true, "All products in cart");
            }
            else { Assert.Fail("Test Failed"); }

            //Click on Checkout button  
            driver.Value.FindElement(By.CssSelector("button[class='btn btn-success']")).Click();

            //Add Text -> Select from Drop-Down
            driver.Value.FindElement(By.CssSelector("#country")).SendKeys("Ind");
            //wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText("India")));
            driver.Value.FindElement(By.LinkText("India")).Click();

            //approve checkout box
            driver.Value.FindElement(By.CssSelector(".checkbox.checkbox-primary")).Click();

            //Click on purches
            driver.Value.FindElement(By.CssSelector("input[value='Purchase']")).Click();

            //Approve 
            string StringData = driver.Value.FindElement(By.CssSelector(".alert.alert-success.alert-dismissible")).Text;
            StringAssert.Contains("Success", StringData);
        }


        public static IEnumerable<TestCaseData> AddTestDataConfig()
        {

            //Test will run 3 times, each time with specified confuguration
            yield return new TestCaseData(jsonData.extractData("username"), jsonData.extractData("password"), jsonData.extractDataArray("Products"));
            //yield return new TestCaseData("rahulshettyacademy", "X");
            //yield return new TestCaseData("Y", "learning");
            
        }

    }
}