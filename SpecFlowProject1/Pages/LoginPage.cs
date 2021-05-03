using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

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
    }
}
