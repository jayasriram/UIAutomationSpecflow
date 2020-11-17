using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Test.PageObjects
{
    class HomePage
    {
        private readonly IWebDriver _driver;

        public HomePage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        public void clickBlockMenu(string blockMenuType)
        {
            var xPathQuery = String.Format("//ul[contains(@class,'sf-menu')]/li/a[@title=\"{0}\"]", blockMenuType);
           _driver.FindElement(By.XPath(xPathQuery)).Click();
           
        }
    }
}
