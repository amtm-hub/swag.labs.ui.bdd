using FluentAssertions;
using OpenQA.Selenium;
using SpecFlowProject1.Pages;
using TechTalk.SpecFlow;

namespace SpecFlowProject1.Steps
{
    [Binding]
    public sealed class LoginStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        
        private readonly LoginPage _loginPage;
        private readonly HomePage _homePage;

        public LoginStepDefinitions(IWebDriver driver, ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _loginPage = new LoginPage(driver);
            _homePage = new HomePage(driver);
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
    }
}
