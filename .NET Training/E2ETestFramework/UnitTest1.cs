using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    internal class E2EShopProduct_F : BaseClass
    {
        //Driver is now inherited from the BaseClass becouse its not available in current class   

        [Test]
        public void FillAllInformation()
        {
            //Enter user name and password 
            driver.Value.FindElement(By.Id("username")).SendKeys("rahulshettyacademy");
            driver.Value.FindElement(By.Id("password")).SendKeys("learning");

            //Select Consultant in drop down
            IWebElement dropdown = driver.Value.FindElement(By.CssSelector("select.form-control"));
            SelectElement choicse = new SelectElement(dropdown);
            choicse.SelectByValue("consult");

            //Click Sign-in button
            driver.Value.FindElement(By.Id("signInBtn")).Click();

            //Add Explisit wait to make sure page is loaded (5S)
            WebDriverWait wait = new WebDriverWait(driver.Value, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementExists(By.CssSelector(".btn.btn-primary.nav-link")));

            //Now we moved to a new window:https://varonis.udemy.com/course/selenium-webdriver-with-csharp-nunit/learn/lecture/28145106#overview
            Assert.AreEqual("https://rahulshettyacademy.com/angularpractice/shop", driver.Value.Url);

            //Select products using array of predefined products we will add
            string[] Preproducts = { "iphone X", "Blackberry" };

            //Create list of all products using product Tags
            IList<IWebElement> products = driver.Value.FindElements(By.TagName("app-card"));

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
            wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText("India")));
            driver.Value.FindElement(By.LinkText("India")).Click();

            //approve checkout box
            driver.Value.FindElement(By.CssSelector(".checkbox.checkbox-primary")).Click();

            //Click on purches
            driver.Value.FindElement(By.CssSelector("input[value='Purchase']")).Click();

            //Approve 
            string StringData = driver.Value.FindElement(By.CssSelector(".alert.alert-success.alert-dismissible")).Text;
            StringAssert.Contains("Success", StringData);
        }
    }
}