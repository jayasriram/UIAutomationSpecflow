using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using Test.PageObjects;
using Test;

namespace Test.Step_Definitions
{
    [Binding]
    public class CommonSteps
    {
        private IWebDriver _driver;

        public CommonSteps(IWebDriver driver) {
            _driver = driver;
        }

  
        [Given(@"I navigate to automation practice site")]
        public void GivenINavigateToAutomationPracticeSite()
        {
            LoginPage loginPage = new LoginPage(_driver);
            _driver.Navigate().GoToUrl("http://automationpractice.com/");
            loginPage.clickSignInBtn();
        }

        [When(@"I logon with username ""(.*)"" with password ""(.*)""")]
        public void WhenILogonWithUsernameWithPassword(string username, string password)
        {
            LoginPage loginPage = new LoginPage(_driver);
            loginPage.userLogin(username,password);
        }

        [Then(@"I should see ""(.*)"" page")]
        public void ThenIShouldSeePage(string pageTitle)
        {
            LoginPage loginPage = new LoginPage(_driver);
            Assert.IsTrue(loginPage.validatePageTile());
        }

    }
}
