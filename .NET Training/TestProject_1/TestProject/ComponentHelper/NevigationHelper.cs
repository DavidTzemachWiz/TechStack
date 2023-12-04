using MStest_TMP.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStest_TMP.ComponentHelper
{
    public class NevigationHelper
    {
        public static void NevigateToSite(string siteUrl) 
        {
            ObjectRepository.Driver.Navigate().GoToUrl(siteUrl);
        }

      
        public static void CloseCurrentBrowser(string CloseOrQuit)
        {
            if (CloseOrQuit == "Close")
            {
                ObjectRepository.Driver.Close();

            }
            else
            {
                ObjectRepository.Driver.Quit();

            }
        }
    }
}
