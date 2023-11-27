using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E2ETestFramework.Utilities_for_test_Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using WebDriverManager.DriverConfigs.Impl;

namespace TestProject1
{
    internal class TextFields:BaseClass
    {
        [Test]
        public void Test_1_ValidateLogInLabel()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            var ValidateUserNamelabel = driver.FindElement(By.XPath("//label[@for='username' and @class='text-white' and text()='Username:']")).Text;
            Assert.AreEqual("Username:",ValidateUserNamelabel);
            TestContext.Progress.WriteLine("page Title is: " + ValidateUserNamelabel);
        }
        [Test]
        public void Test_1_LogInPage_ErrorValidation()
        {
            //Enter user name and password 
            driver.FindElement(By.Id("username")).SendKeys("Wrong Details");
            driver.FindElement(By.Id("password")).SendKeys("Wrong Details");

            //Click on Submit 
            driver.FindElement(By.Name("signin")).Click();
            Thread.Sleep(3000);

            var Error = driver.FindElement(By.ClassName("alert-danger")).Text;
            Assert.AreEqual("Incorrect username/password.", Error);
            //Or
            Assert.That(Error, Is.EqualTo("Incorrect username/password."));
            
        }

        [Test]
        public void ValidateCheckbox()
        {
            IWebElement terms = driver.FindElement(By.Id("terms"));
            TestContext.Progress.WriteLine("Is Checkbox selected? " +terms.Selected);//false
            terms.Click();
            TestContext.Progress.WriteLine("Is Checkbox selected? " + terms.Selected);//True 
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
                TestContext.Progress.WriteLine("Item in list: " +item.Text + " | " + item.Selected);
            }
            driver.Close();
        }
    }
}
