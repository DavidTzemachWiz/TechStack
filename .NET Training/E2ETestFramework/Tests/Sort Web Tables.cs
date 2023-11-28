using System;
using System.Collections;
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
    internal class Sort_Web_Tables:BaseClass
    {
        
        [Test]
        public void FillAllInformaAtion()
        {
            driver.Value.Url = "https://rahulshettyacademy.com/seleniumPractise/#/offers";
            //Change from 5 rows to 10 
            //Select the Drop-Down Values 
            IWebElement dropdown = driver.Value.FindElement(By.Id("page-menu"));
            SelectElement choicse = new SelectElement(dropdown);
            choicse.SelectByIndex(2);

            //step 1 - get all volues in column into array list A and sort it
            ArrayList A = new ArrayList();
            IList<IWebElement> fruite = driver.Value.FindElements(By.XPath("//td[1]"));

            foreach (var item in fruite)
            {
                TestContext.Progress.WriteLine(item.Text);
                A.Add(item.Text);
            }

            A.Sort();

            //step 2 - Click on column header to sort
            driver.Value.FindElement(By.XPath("//th[1]")).Click();


            //step 3 - get all volues in column into array list B(Now its surted)
            ArrayList B = new ArrayList();
           fruite = driver.Value.FindElements(By.XPath("//td[1]"));
            foreach (var item in fruite)
            {
                TestContext.Progress.WriteLine(item.Text);
                B.Add(item.Text);
            }

            //step 4 - Compate Array lists to check if sorted correctly
            Assert.AreEqual(A, B);
        }
    }
}