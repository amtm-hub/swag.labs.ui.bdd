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

        private IWebElement LoginLogoEl => _driver.FindElement(By.XPath("//div[@class='login_logo']"));
        public bool IsLoginLogoDisplayed => LoginLogoEl.Displayed;

        private IWebElement UsernameEl => _driver.FindElement(By.Id("user-name"));
        public void SetUsername(string username = null) => UsernameEl.SendKeys(username);
        
        private IWebElement PasswordEl => _driver.FindElement(By.Id("password"));
        public void SetPassword(string password = null) => PasswordEl.SendKeys(password);

        private IWebElement LoginEl => _driver.FindElement(By.Id("login-button"));
        public void ClickLogin() => LoginEl.Click();

        private IWebElement ErrorMessageEl => _wait.Until(ExpectedConditions.ElementExists(By.XPath("//h3[@data-test='error']")));
        public string ErrorMessage => ErrorMessageEl.Text;
    }
}
