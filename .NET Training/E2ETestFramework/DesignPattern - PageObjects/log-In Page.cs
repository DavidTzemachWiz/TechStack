using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E2ETestFramework.Utilities_for_test_Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using WebDriverManager.DriverConfigs.Impl;

namespace E2ETestFramework.POM_Classes
{
    public class log_In_Page
    {
        private IWebDriver driver;

        public log_In_Page(IWebDriver driver)
        {
            //initializing the driver used for this class
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        //Example 1: In test Class before POM: driver.FindElement(By.Id("username"))
        //With Pageobject Factory 
        [FindsBy(How = How.Id, Using = "username")]
        private IWebElement username;

        //Create a method that will return the user name 
        public IWebElement getUserName()
        {
            return username;
        }

        //Example 2: In test Class before POM: driver.FindElement(By.Id("password"));
        //With Pageobject Factory 
        [FindsBy(How = How.Id, Using = "password")]
        private IWebElement password;

        //Create a method that will return the password
        public IWebElement getPassword()
        {
            return password;
        }

        //Example 3: driver.FindElement(By.CssSelector("select.form-control"));
        [FindsBy(How = How.CssSelector, Using = "select.form-control")]
        private IWebElement dropdown;

        //Create a method that will return the password
        public IWebElement getdropdown()
        {
            return dropdown;
        }

        //Example 4: driver.FindElement(By.Id("signInBtn")).Click();
        [FindsBy(How = How.Id, Using = "signInBtn")]
        private IWebElement signInBtn;

        public IWebElement getSignInBtn()
        {
            return signInBtn;
        }

        //Creating a method that will perform E2E logInProces
        public void User_and_Pass(string Username, string Password)
        {
        username.SendKeys(Username);
        password.SendKeys(Password);

        }
    }


}


