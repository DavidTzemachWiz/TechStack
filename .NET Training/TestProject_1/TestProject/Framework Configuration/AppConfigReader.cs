using MStest_TMP.Framework_Utilities;
using MStest_TMP.Settings;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStest_TMP.Framework_Configuration
{
    public class AppConfigReader : Iconfig
    {
        public BrowserType GetBrowser()
        {
            string browser = ConfigurationManager.AppSettings.Get(AppConfigKeys.Browser);
            return (BrowserType)Enum.Parse(typeof(BrowserType),browser);     
        }

        public string GetUrl()
        {
            return ConfigurationManager.AppSettings.Get(AppConfigKeys.TestSite);
        }

        public string GetUserName()
        {
            return ConfigurationManager.AppSettings.Get(AppConfigKeys.UserName);
        }

        public string GetUserPass()
        {
            return ConfigurationManager.AppSettings.Get(AppConfigKeys.Password);
        }
    }
}
