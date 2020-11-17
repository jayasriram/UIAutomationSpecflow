using BoDi;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using TechTalk.SpecFlow;
using System.Drawing;
//using System.Windows.Forms;

//using GhprSpecFlow.Common;

namespace UnitTestProject1
{
    [Binding]
    public class Hooks
    {
        private IObjectContainer _objectContainer;
        protected IWebDriver _driver;

     

        public Hooks(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;

        }

        [BeforeScenario]
        public void Init()
        {
            _driver = new ChromeDriver();
            _objectContainer.RegisterInstanceAs<IWebDriver>(_driver);
            _driver.Manage().Window.Maximize();
            
        }

        [AfterScenario]
        public void CloseBrowser()
        {
            _driver.Quit();
        }

        
    }
}
