using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Test.PageObjects;
using Test;

namespace Test
{
    [Binding]
    class HomePageSteps
    {

        private IWebDriver _driver;

        public HomePageSteps(IWebDriver driver)
        {
            _driver = driver;
            LoginPage loginPage = new LoginPage(_driver);
        }

      

        [Then(@"I should see that my cart is empty")]
        public void ThenIShouldSeeThatMyCartIsEmpty()
        {
            LoginPage loginPage = new LoginPage(_driver);
            Assert.IsTrue(loginPage.validateCartEmpty());

        }

        [When(@"I navigate to the ""(.*)"" section")]
        public void WhenINavigateToTheSection(string blockMenu)
        {
            HomePage homePage = new HomePage(_driver);
            homePage.clickBlockMenu(blockMenu);
        }

        [When(@"I add the following product to cart")]
        public void WhenIAddTheFollowingProductToCart(Table table)
        {
            DressesPage dressesPage = new DressesPage(_driver);
           dressesPage.WhenUserAddsProductToCart(table);
        }

        [Then(@"I should see the success message for adding to cart as ‘Product successfully added to your shopping cart")]
        public void ThenIShouldSeeTheSuccessMessageForAddingToCartAsProductSuccessfullyAddedToYourShoppingCart()
        {
            DressesPage dressesPage = new DressesPage(_driver);
            Assert.AreEqual("Product successfully added to your shopping cart", dressesPage.getSuccessPageTitle());
        }

        [Then(@"I should see the number of products in cart as ""(.*)""")]
        public void ThenIShouldSeeTheNumberOfProductsInCartAs(int p0)
        {
            DressesPage dressesPage = new DressesPage(_driver);
            Assert.AreEqual("There is 1 item in your cart.", dressesPage.getItemsInCartText());
        }

        [Then(@"I should land on the ""(.*)"" page")]
        public void ThenIShouldLandOnThePage(string dressesPageTitle)
        {
            DressesPage dressesPage = new DressesPage(_driver);
            Assert.IsTrue(dressesPage.validatePageTile());
        }

        [Then(@"I should see the below products on offer with appropriate price")]
        public void ThenIShouldSeeTheBelowProductsOnOfferWithAppropriatePrice(Table table)
        {
            DressesPage dressesPage = new DressesPage(_driver);
            dressesPage.WhenUserSelectsProductsOnOffer(table);
        }


    }
}
