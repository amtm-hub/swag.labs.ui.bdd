using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SpecFlowProject1.Pages
{
    public sealed class SelectYourLanguagePage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public SelectYourLanguagePage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        }

        private IWebElement LanguageContainerEl => _wait.Until(ExpectedConditions.ElementExists(By.XPath("//div[@role='dialog']//div[@id='language_container']")));
        public List<string> Languages()
        {
            var stringSeparators = new[] { "\r\n" };
            var languages = LanguageContainerEl.Text.Split(stringSeparators, StringSplitOptions.None).ToList();
            return languages;
        }
    }
}
