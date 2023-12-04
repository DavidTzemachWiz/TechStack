using MStest_TMP.ComponentHelper;
using MStest_TMP.Settings;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStest_TMP.Test_Scripts.TestWebElements
{
    [TestClass]

    public class TestWebElement
    {

        [TestMethod]
        public void GetElement()
        {
            NevigationHelper.NevigateToSite("http://localhost:5001/");


            //Validation 
            Console.WriteLine("Is element Displayed? " + SiteElementValidations.IsElementDisplayed(By.Id("quicksearch_top")));
            try
            {
                ObjectRepository.Driver.FindElement(By.Id("quicksearch_top")).SendKeys("dddddd");

            }
            catch(NoSuchElementException eg)
            {
                Console.WriteLine(eg);
            }
            Thread.Sleep(3000);
        }

        [TestMethod]
        public void GetElement_2()
        {
            NevigationHelper.NevigateToSite("http://localhost:5001/");

            Console.WriteLine("Is element Displayed? " + SiteElementValidations.IsElementDisplayed(By.Id("quicksearch_top")));

        }
    }
}
