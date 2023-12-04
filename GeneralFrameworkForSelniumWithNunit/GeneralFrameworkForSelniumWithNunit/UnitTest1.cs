using GeneralFrameworkForSelniumWithNunit.Component_Helpers;
using GeneralFrameworkForSelniumWithNunit.TestHelpers;
using GeneralFrameworkForSelniumWithNunit.Utilities;
using Microsoft.VisualStudio.TestPlatform.PlatformAbstractions.Interfaces;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;

namespace GeneralFrameworkForSelniumWithNunit
{
    public class Tests : BaseClass
    {
       
        [Test]
        public void Test1()
        {
            //BrowserCommands.NevigateToUrl(driver.Value,"http://www.walla.co.il");
            driver.Value.FindElement(By.Id("username")).SendKeys("rahulshettyacademya");

            //System.Console.WriteLine(BrowserProporties.NevigateToUrl(driver.Value));
        }
    }
}