using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeneralFrameworkForSelniumWithNunit.Component_Helpers
{
    public class WebElementsValidations
    {
        //Validate if an element is Enabled
        public static bool IsElementEnabled(By locator, IWebDriver driver)
        {
            try
            {
                bool IsElementEnabled = driver.FindElement(locator).Enabled;
                return IsElementEnabled;
            }
            catch (Exception)
            {
                return false;
            }
            
        }
    }
}
