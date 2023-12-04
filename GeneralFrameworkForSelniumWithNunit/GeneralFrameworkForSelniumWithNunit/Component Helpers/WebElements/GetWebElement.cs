using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeneralFrameworkForSelniumWithNunit.Component_Helpers
{
    public class GetWebElement
    {
        public static IWebElement GetElement(IWebDriver driver, By locator)
        {
            if (WebElementsValidations.IsElementDisplayed(locator ,driver) == true)
            {
                return driver.FindElement(locator);
            }
            else
            {
                throw new NoAlertPresentException("Element not found " + locator.ToString());
            }
        }
    }
}
