using GeneralFrameworkForSelniumWithNunit.Component_Helpers;
using GeneralFrameworkForSelniumWithNunit.TestHelpers;
using GeneralFrameworkForSelniumWithNunit.Utilities;
using Microsoft.VisualStudio.TestPlatform.PlatformAbstractions.Interfaces;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Threading;

namespace GeneralFrameworkForSelniumWithNunit
{
    public class Tests : BaseClass
    {
       
        [Test]
        public void Test1()
        {
            //BrowserCommands.NevigateToUrl(driver.Value,"http://www.walla.co.il");
            //driver.Value.FindElement(By.Id("username")).SendKeys("rahulshettyacademya");

            TextFields.EnterText(driver.Value, By.Id("username"), "Text To Add into Field");
            TextFields.ClearText(driver.Value, By.Id("username"));
            //GetWebElement.GetElement(driver.Value,By.Id("username")).SendKeys("rahulshettyacademya");
            Console.WriteLine("Is Element Displayed" + WebElementsValidations.IsElementDisplayed(By.Id("username"), driver.Value));
            Console.WriteLine("Is Element Enabled" + WebElementsValidations.IsElementEnabled(By.Id("username"), driver.Value));
        }
    }
}