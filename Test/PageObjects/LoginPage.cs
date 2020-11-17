using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace Test.PageObjects
{
    class LoginPage
    {
        private readonly IWebDriver _driver;

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//a[@class='login']")]
        protected IWebElement SignInBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id=\"email\"]")]
        protected IWebElement EmailTextBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id=\"passwd\"]")]
        protected IWebElement PswdTextBox { get; set; }
  
        [FindsBy(How = How.XPath, Using = "//button[@id=\"SubmitLogin\"]")]
        protected IWebElement SubmitBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//h1[text()=\"My account\"]")]
        protected IWebElement MyaccountPageTitle { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class=\"shopping_cart\"]//span[text()=\"(empty)\"]")]
        protected IWebElement EmptyCartText { get; set; }

        [FindsBy(How = How.Id, Using = "login_form")]
        protected IWebElement LoginPageForm { get; set; }
        


        public void clickSignInBtn()
        {
            SignInBtn.Click();

        }

        public void userLogin(string username,string password)
        {

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => LoginPageForm.Displayed);

            EmailTextBox.SendKeys(username);
            PswdTextBox.SendKeys(password);
            SubmitBtn.Click();
        }

        public bool validatePageTile()
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Boolean IsPageTile = false;
            if (MyaccountPageTitle.Displayed)
                IsPageTile = true;
            else
                IsPageTile = false;

            return IsPageTile;
        }

        public bool validateCartEmpty()
        {
            Boolean IsCartEmpty = false;
            if (EmptyCartText.Displayed)
                IsCartEmpty = true;
            else
                IsCartEmpty = false;

            return IsCartEmpty;
        }

    }
}
