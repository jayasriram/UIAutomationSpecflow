using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using OpenQA.Selenium.Support.UI;

namespace Test.PageObjects
{
    class DressesPage
    {

        private readonly IWebDriver _driver;

        public DressesPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }


        [FindsBy(How = How.XPath, Using = " //h1[contains(@class,'page-heading')]/span[contains(text(),'Dresses')]")]
        protected IWebElement dressesPageTitle { get; set; }

        [FindsBy(How = How.XPath, Using = "//p[@id=\"add_to_cart\"]")]
        protected IWebElement AddToCartBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'layer_cart_product')]//h2")]
        protected IWebElement successPageTitle { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'layer_cart_cart')]//span[@class=\"ajax_cart_product_txt \"]")]
        protected IWebElement itemsInCartText { get; set; }


        public bool validatePageTile()
        {
           Boolean IsPageTile = false;
            if (dressesPageTitle.Displayed)
                IsPageTile = true;
            else
                IsPageTile = false;

            return IsPageTile;
        }

        public bool WhenUserSelectsProductsOnOffer(Table table)
        {
            bool IsPriceValid = false;
            var offerPriceDataTable = table.CreateSet<Product>();
            foreach (var offerPriceData in offerPriceDataTable)
            {
                var productName = offerPriceData.products;
                var productPrice = offerPriceData.productPrice;
                var OldPrice = offerPriceData.oldPrice;
                var offerPercentage = offerPriceData.offerPercentage;

                IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
                js.ExecuteScript("window.scrollTo(800, 800)");
                
                    bool isProductPricePresent = _driver.FindElement(By.XPath("//a[@title='"+productName+"']/ancestor::div[@class=\"right-block\"]//div[@itemprop=\"offers\"]/span[@class=\"price product-price\" and contains(text(),'28.98')]")).Displayed;
                    bool isProductOldPricePresent = _driver.FindElement(By.XPath("//a[@title='" + productName + "']/ancestor::div[@class=\"right-block\"]//div[@itemprop=\"offers\"]/span[@class=\"old-price product-price\" and contains(text(),'" + OldPrice + "')]")).Displayed;
                    bool isReductionPercentagePresent = _driver.FindElement(By.XPath("//a[@title='" + productName + "']/ancestor::div[@class=\"right-block\"]//div[@itemprop=\"offers\"]/span[@class=\"price-percent-reduction\" and contains(text(),'" + offerPercentage + "')]")).Displayed;

                    if (isProductPricePresent && isProductOldPricePresent && isReductionPercentagePresent)
                    {
                        IsPriceValid = true;
                    }
                    else
                        IsPriceValid = false;
            }
            return IsPriceValid;
        }


        public void WhenUserAddsProductToCart(Table table)
        {
            var ItemsToCartTable = table.CreateSet<AddToCart>();
            foreach (var item in ItemsToCartTable)
            {
                var productName = item.product;
                var productColour = item.colour;
                var productSize = item.size;

                var productNameXpathQuery = String.Format(" //div[@class=\"right-block\"]//a[@title=\"{0}\"]", productName);
                _driver.FindElement(By.XPath(productNameXpathQuery)).Click();
                var productColourXpathQuery = String.Format("//ul[@id=\"color_to_pick_list\"]//a[@title=\"Blue\"]", productColour);
                _driver.FindElement(By.XPath(productColourXpathQuery)).Click();
                SelectElement sizeSelect = new SelectElement(_driver.FindElement(By.XPath("//div[@class=\"selector\"]/select")));              
                sizeSelect.SelectByText(productSize);
                AddToCartBtn.Click();                
            }
        }

        public string getSuccessPageTitle()
        {        
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(driver =>successPageTitle.Displayed);
            var pageTitleText = successPageTitle.Text;
            return pageTitleText;
        }

        public string getItemsInCartText()
        {
            var itemsInCartTextActual = itemsInCartText.Text;
            return itemsInCartTextActual;
        }

    }
}
