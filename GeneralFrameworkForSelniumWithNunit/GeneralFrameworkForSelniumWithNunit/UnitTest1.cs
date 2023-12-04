using GeneralFrameworkForSelniumWithNunit.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;

namespace GeneralFrameworkForSelniumWithNunit
{
    public class Tests : BaseClass
    {
      
        [Test]
        public void Test1()
        {
            driver.Value.FindElement(By.Id("usernamea")).SendKeys("rahulshettyacademya");
            Assert.Pass();
        }
    }
}