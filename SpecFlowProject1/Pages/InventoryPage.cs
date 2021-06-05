using OpenQA.Selenium;

namespace SpecFlowProject1.Pages
{
    public sealed class InventoryPage
    {
        private IWebDriver _driver;

        public InventoryPage(IWebDriver driver)
        {
            _driver = driver;
        }

        private IWebElement ImageEl => _driver.FindElement(By.XPath("//div[@class='inventory_details_img_container']/img"));
        public string ImageSource => ImageEl.GetAttribute("src");

        private IWebElement NameEl => _driver.FindElement(By.XPath("//div[contains(@class,'inventory_details_name')]"));
        public string Name => NameEl.Text;

        private IWebElement DescriptionEl => _driver.FindElement(By.XPath("//div[contains(@class,'inventory_details_desc')]"));
        public string Description => DescriptionEl.Text;

        private IWebElement PriceEl => _driver.FindElement(By.XPath("//div[@class='inventory_details_price']"));
        public string Price => PriceEl.Text;

        private IWebElement AddToCartButtonEl => _driver.FindElement(By.XPath("//button[text()='Add to cart']"));
        public bool IsAddToCartEnabled => AddToCartButtonEl.Enabled;
    }
}
