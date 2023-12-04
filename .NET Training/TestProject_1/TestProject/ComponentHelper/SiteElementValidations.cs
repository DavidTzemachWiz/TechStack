using MStest_TMP.Settings;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStest_TMP.ComponentHelper
{
    public class SiteElementValidations
    {

        public static bool IsElementEnabled(By locator)
        {
            bool IsElementEnabled = ObjectRepository.Driver.FindElement(locator).Enabled;
            return IsElementEnabled;
        }

        public static bool IsElementDisplayed(By locator)
        {
            try
            {
                bool IsElementDisplayed = ObjectRepository.Driver.FindElement(locator).Displayed;
                return IsElementDisplayed;
            }
            catch (Exception)
            {
                return false;        
            }
            
        }

        public static IWebElement GetElement(By locator)
        {
            if (IsElementDisplayed(locator) == true)
            {
                return ObjectRepository.Driver.FindElement(locator);
            }
            else
            {
                throw new NoAlertPresentException("Element not found " + locator.ToString());
            }

        }

    }
}
