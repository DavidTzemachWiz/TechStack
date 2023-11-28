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
namespace E2ETestFramework.Tests
{
    [Parallelizable(ParallelScope.Children)]
    internal class ParallelTesting:BaseClass
    {      
        [Test, Category("Sanity")]
        [TestCase("WrongUSer_1", "Wrong Pass_1")]
        [TestCase("WrongUSer_2", "Wrong Pass_2")]
        [TestCase("WrongUSer_3", "Wrong Pass_3")]
        [TestCase("WrongUSer_4", "Wrong Pass_4")]
        [TestCase("WrongUSer_5", "Wrong Pass_5")]
        [Parallelizable(ParallelScope.All)]
        public void ParrallelTest_1(string US, string PS)
        {
            //Enter user name and password 
            driver.Value.FindElement(By.Id("username")).SendKeys(US);
            driver.Value.FindElement(By.Id("password")).SendKeys(PS);

            //Click on Submit 
            driver.Value.FindElement(By.Name("signin")).Click();
            Thread.Sleep(3000);

            var Error = driver.Value.FindElement(By.ClassName("alert-danger")).Text;
            Assert.AreEqual("Incorrect username/password.", Error);
            //Or
            Assert.That(Error, Is.EqualTo("Incorrect username/password."));

        }
        [Test, Category("Regression")]
        public void ParrallelTest_2()
        {
            //Enter user name and password 
            driver.Value.FindElement(By.Id("username")).SendKeys("dd");
            driver.Value.FindElement(By.Id("password")).SendKeys("dd");

            //Click on Submit 
            driver.Value.FindElement(By.Name("signin")).Click();
            Thread.Sleep(3000);

            var Error = driver.Value.FindElement(By.ClassName("alert-danger")).Text;
            Assert.AreEqual("Incorrect username/password.", Error);
            //Or
            Assert.That(Error, Is.EqualTo("Incorrect username/password."));

        }
    }
}
