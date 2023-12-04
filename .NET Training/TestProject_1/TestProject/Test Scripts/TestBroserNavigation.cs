using MStest_TMP.ComponentHelper;
using MStest_TMP.Framework_Utilities;
using MStest_TMP.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStest_TMP.Test_Scripts.BrowserNav
{
    [TestClass]
    public class TestBroserNavigation : BaseClass
    {
        [TestMethod]
        public void OpenSite()
        {
            //ObjectRepository.Driver.Navigate().GoToUrl(ObjectRepository.Config.GetUrl());
            //Or using the Helper class 
            NevigationHelper.NevigateToSite(ObjectRepository.Config.GetUrl());

            //Get Browser Title
            string title = SiteProporties.GetSiteTitle();
            string SiteURL = SiteProporties.GetSiteURL();
            Console.WriteLine("page Title: " + title + "\n" + "Page URL: " + SiteURL);
         
            NevigationHelper.CloseCurrentBrowser("Close");
        }
    }
}
