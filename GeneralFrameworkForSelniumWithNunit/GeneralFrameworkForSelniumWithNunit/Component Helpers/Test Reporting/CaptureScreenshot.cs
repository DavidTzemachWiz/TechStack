using AventStack.ExtentReports;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeneralFrameworkForSelniumWithNunit.Component_Helpers.Test_Reporting
{
    public class CaptureScreenshotForTests
    {


        public static MediaEntityModelProvider CaptureScreenshots(IWebDriver driver, string screenShotName)
        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            var screenshot = ts.GetScreenshot().AsBase64EncodedString;
            return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot, screenShotName).Build();
        }
    }
}
