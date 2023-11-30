using MStest_TMP.Framework_Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStest_TMP.Settings
{
    public class ObjectRepository
    {
        public static Iconfig Config { get; set; }
        public static IWebDriver Driver { get; set; }

    }
}
