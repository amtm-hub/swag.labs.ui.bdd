using FluentAssertions;
using OpenQA.Selenium;
using SpecFlowProject1.Pages;
using System;
using System.Linq;
using TechTalk.SpecFlow;

namespace SpecFlowProject1.Steps
{
    [Binding]
    public sealed class LoginStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        
        private readonly LoginPage _loginPage;
        private readonly HomePage _homePage;
        private readonly SelectYourLanguagePage _selectYourLanguagePage;

        public LoginStepDefinitions(IWebDriver driver, ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _loginPage = new LoginPage(driver);
            _homePage = new HomePage(driver);
            _selectYourLanguagePage = new SelectYourLanguagePage(driver);
        }

        [Given(@"Susie is on login screen")]
        public void GivenSusieIsOnLoginScreen()
        {
            _loginPage.NavigateToPage();
        }

        [When(@"she logs in with blank username and password")]
        public void WhenSheLogsInWithBlankUsernameAndPassword()
        {
            _loginPage.ClickLogin();
        }

        [When(@"she logs in with")]
        public void WhenSheLogsInWith(Table table)
        {
            var username = table.Rows[0][0];
            var password = table.Rows[1][0];

            _loginPage.SetUsername(username);
            _loginPage.SetPassword(password);
            _loginPage.ClickLogin();
        }

        [When(@"she views the list of available languages")]
        public void WhenSheViewsTheListOfAvailableLanguages()
        {
            _loginPage.ClickLanguageSelector();
        }

        [When(@"she switches to ""(.*)"" language")]
        public void WhenSheSwitchesToLanguage(string language)
        {
            _loginPage.SelectLanguageFromFooter(language);
        }

        [Then(@"the email error message ""(.*)"" will be displayed")]
        public void ThenTheEmailErrorMessageWillBeDisplayed(string message)
        {
            _loginPage.EmailErrorMessage.Should().Be(message);
        }

        [Then(@"the password error message ""(.*)"" will be displayed")]
        public void ThenThePasswordErrorMessageWillBeDisplayed(string message)
        {
            _loginPage.PasswordErrorMessage.Should().Be(message);
        }

        [Then(@"the homepage is displayed")]
        public void ThenTheHomepageIsDisplayed()
        {
            _homePage.IsHomeLinkDisplayed().Should().Be(true);
        }

        [Then(@"the Select Your Language modal is displayed with a list of languages")]
        public void ThenTheSelectYourLanguageModalIsDisplayedWithAListOfLanguages(string multilineText)
        {
            var stringSeparators = new[] { "\r\n" };
            var expLanguages = multilineText.Split(stringSeparators, StringSplitOptions.None).ToList();
            _selectYourLanguagePage.Languages().Should().BeEquivalentTo(expLanguages);
        }

        [Then(@"the language on the login screen is translated")]
        public void ThenTheLanguageOnTheLoginScreenIsTranslated(Table table)
        {
            var expLoginText = table.Rows[0]["values"];
            var expForgotPasswordText = table.Rows[1]["values"];
            var expCreateAccountText = table.Rows[2]["values"];

            _loginPage.LoginText.Should().Be(expLoginText);
            _loginPage.ForgotPasswordText.Should().Be(expForgotPasswordText);
            _loginPage.CreateAccountText.Should().Be(expCreateAccountText);
        }
    }
}
