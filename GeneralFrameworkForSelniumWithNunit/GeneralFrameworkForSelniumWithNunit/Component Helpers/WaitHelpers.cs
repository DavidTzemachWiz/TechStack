using MongoDB.Driver.Core.Operations;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace GeneralFrameworkForSelniumWithNunit.Component_Helpers
{
    public class WaitHelpers
    {
        public static void ImplicitWait(IWebDriver driver, int SecondsToWait)
        {            
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(SecondsToWait);            
        }

                      

    }
}
