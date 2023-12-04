using MStest_TMP.Settings;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStest_TMP.ComponentHelper
{
    public class TextFieldHelper
    {
        private static IWebElement element;
        public static void  TypeInTextBox (By locator, string Text)
        {
           element = SiteElementValidations.GetElement(locator);
           element.SendKeys(Text);

        }

        public static void ClearText(By locator)
        {
            element = SiteElementValidations.GetElement(locator);
            element.Clear();

        }
    }
}
