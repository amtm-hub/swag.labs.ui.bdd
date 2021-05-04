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

        public void NavigateToPage()
        {
            _driver.Navigate().GoToUrl("https://www.facebook.com/");
            _wait.Until(ExpectedConditions.ElementExists(By.Name("login")));
        }

        private IWebElement UsernameEl => _driver.FindElement(By.Id("email"));
        public void SetUsername(string username = null) => UsernameEl.SendKeys(username);
        
        private IWebElement PasswordEl => _driver.FindElement(By.Id("pass"));
        public void SetPassword(string password = null) => PasswordEl.SendKeys(password);

        private IWebElement LoginEl => _driver.FindElement(By.Name("login"));
        public void ClickLogin() => LoginEl.Click();

        private IWebElement EmailErrorMessageEl => _wait.Until(ExpectedConditions.ElementExists(By.XPath("//div[@id='email_container']/div[@class='_9ay7']")));
        public string EmailErrorMessage => EmailErrorMessageEl.Text;

        private IWebElement PasswordErrorMessageEl => _wait.Until(ExpectedConditions.ElementExists(By.XPath("//div[@class='clearfix _5466 _44mg']/div[@class='_9ay7']")));
        public string PasswordErrorMessage => PasswordErrorMessageEl.Text;

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
