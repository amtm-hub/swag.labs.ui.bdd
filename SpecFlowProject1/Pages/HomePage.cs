using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;

namespace SpecFlowProject1.Pages
{
    public sealed class HomePage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public HomePage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
        }

        private IWebElement HomeLinkEl => _wait.Until(ExpectedConditions.ElementExists(By.Id("inventory_container")));
        public bool IsHomeLinkDisplayed() => HomeLinkEl.Displayed;

        public IEnumerable<ProductPage> Products
        {
            get
            {
                var products = _driver.FindElements(By.XPath("//div[@class='inventory_item']"));
                var list = new List<ProductPage>();
                foreach (var product in products)
                {
                    list.Add(new ProductPage(_driver, product));
                }
                return list;
            }
        }
    }

    public sealed class ProductPage
    {
        private IWebDriver _driver;
        private IWebElement _el;

        public ProductPage(IWebDriver driver, IWebElement el)
        {
            _driver = driver;
            _el = el;
        }

        private IWebElement ItemImageEl => _el.FindElement(By.XPath("//div[@class='inventory_item_img']/a/img"));
        public string ItemImageSource => ItemImageEl.GetAttribute("src");

        private IWebElement ItemDescriptionEl => _el.FindElement(By.XPath("//div[@class='inventory_item_description']"));
        public string ItemDescription => ItemDescriptionEl.Text;

        private IWebElement ItemPriceBarEl => _el.FindElement(By.XPath("//div[@class='pricebar']"));
        public string ItemPrice => ItemPriceBarEl.Text;

        private IWebElement AddToCartButtonEl => _el.FindElement(By.XPath("//div[@class='pricebar']/button"));
        public bool IsAddToCartEnabled => AddToCartButtonEl.Enabled;

        private IWebElement ItemLinkEl => _el.FindElement(By.XPath("//div[@class='inventory_item_img']/a"));
        public void Click() => ItemLinkEl.Click();
    }
}
