using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E2ETestFramework.Utilities_for_test_Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using WebDriverManager.DriverConfigs.Impl;

namespace E2ETestFramework.DesignPattern___PageObjects
{
    public class ProductPage
    {
        private IWebDriver driver;

            public ProductPage(IWebDriver driver)
            {
                this.driver = driver;
                PageFactory.InitElements(driver, this);
            }

        //Example 1: driver.FindElements(By.TagName("app-card"));
        //With Pageobject Factory 
        [FindsBy(How = How.TagName, Using = "app-card")]
        private IList<IWebElement> cards;

        //Create a method that will return the user name 
        public IList<IWebElement> getAppCard()
        {
            return cards;
        }

        //Example 2: Method for Explicit wait
        public void WaitForPageDisplay(int timeToWait)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeToWait));
            wait.Until(ExpectedConditions.ElementExists(By.CssSelector(".btn.btn-primary.nav-link")));
        }


        
    }
}
