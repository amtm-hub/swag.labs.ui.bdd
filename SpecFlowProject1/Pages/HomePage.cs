using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

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

        private IWebElement HomeLinkEl => _wait.Until(ExpectedConditions.ElementExists(By.XPath("//a[@aria-label='Home']")));
        public bool IsHomeLinkDisplayed() => HomeLinkEl.Displayed;
    }
}
