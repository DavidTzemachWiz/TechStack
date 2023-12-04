using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeneralFrameworkForSelniumWithNunit.Component_Helpers
{
    public class TextFields
    {
        private static IWebElement element;

        public static void EnterText(IWebDriver driver, By locator , string TestToAdd)
        {
            element = GetWebElement.GetElement(driver, locator);
            element.SendKeys(TestToAdd);
        }

        public static void ClearText(IWebDriver driver, By locator)
        {
            element = GetWebElement.GetElement(driver, locator);
            element.Clear();            
        }

        public static void SimulateEnter(IWebDriver driver, By locator)
        {
            element = GetWebElement.GetElement(driver, locator);
            element.Submit();

        }
    }
}
