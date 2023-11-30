using OpenQA.Selenium.DevTools.V117.Browser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStest_TMP.Framework_Utilities
{
    public interface Iconfig
    {
        BrowserType GetBrowser();
        string GetUserName();
        string GetUserPass();
        string GetUrl();
    }
}
