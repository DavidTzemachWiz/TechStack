using MStest_TMP.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStest_TMP.ComponentHelper
{
    public class SiteProporties
    {
        public static string GetSiteURL()
        {          
           string SiteURL = ObjectRepository.Driver.Url;
           return SiteURL;
        }

        public static string GetSiteTitle()
        {
            string SiteTitle = ObjectRepository.Driver.Title;
            return SiteTitle;
        }
    }
}
