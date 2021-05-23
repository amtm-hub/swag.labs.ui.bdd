using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SpecFlowProject1.Pages
{
    public sealed class LoginPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
        }

        public void NavigateToPage(string page)
        {
            var url = page.ToLowerInvariant() == "swaglabs"
                ? "https://www.saucedemo.com/"
                : "https://www.facebook.com/";
            
            _driver.Navigate().GoToUrl(url);

            var xpath = page.ToLowerInvariant() == "swaglabs"
                ? "//div[@class='login_logo']"
                : "//button[@name='login']";
            _wait.Until(ExpectedConditions.ElementExists(By.XPath($"{xpath}")));
        }

        private IWebElement UsernameEl => _driver.FindElement(By.Id("user-name"));
        public void SetUsername(string username = null) => UsernameEl.SendKeys(username);
        
        private IWebElement PasswordEl => _driver.FindElement(By.Id("password"));
        public void SetPassword(string password = null) => PasswordEl.SendKeys(password);

        private IWebElement LoginEl => _driver.FindElement(By.Id("login-button"));
        public void ClickLogin() => LoginEl.Click();

        private IWebElement ErrorMessageEl => _wait.Until(ExpectedConditions.ElementExists(By.XPath("//h3[@data-test='error']")));
        public string ErrorMessage => ErrorMessageEl.Text;
        
        private IWebElement SelectorEl => _driver.FindElement(By.XPath("//div[@id='pageFooter']//a[@role='button']"));
        public void ClickLanguageSelector() => SelectorEl.Click();

        private IEnumerable<IWebElement> LanguageEl => _driver.FindElements(By.XPath("//div[@id='pageFooter']//li"));
        public void SelectLanguageFromFooter(string language)
        {
            LanguageEl.Single(x => x.Text.Contains(language)).Click();
        }

        private IWebElement LoginButtonEl => _wait.Until(ExpectedConditions.ElementExists(By.Name("login")));
        public string LoginText => LoginButtonEl.Text;

        private IWebElement ForgotPasswordLinkEl => _wait.Until(ExpectedConditions.ElementExists(By.XPath("//div[@class='_6ltj']/a")));
        public string ForgotPasswordText => ForgotPasswordLinkEl.Text;

        private IWebElement CreateAccountLinkEl => _wait.Until(ExpectedConditions.ElementExists(By.XPath("//div[@class='_6ltg']/a")));
        public string CreateAccountText => CreateAccountLinkEl.Text;
    }
}
