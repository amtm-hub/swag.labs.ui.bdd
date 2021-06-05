using FluentAssertions;
using OpenQA.Selenium;
using SpecFlowProject1.Context;
using SpecFlowProject1.Pages;
using TechTalk.SpecFlow;

namespace SpecFlowProject1.Steps
{
    [Binding]
    public sealed class LoginStepDefinitions
    {
        private readonly IWebDriver _driver;
        private readonly SharedContext _sharedContext;
        private readonly LoginPage _loginPage;
        private readonly HomePage _homePage;
        
        public LoginStepDefinitions(IWebDriver driver, SharedContext sharedContext)
        {
            _driver = driver;
            _sharedContext = sharedContext;
            _loginPage = new LoginPage(driver);
            _homePage = new HomePage(driver);
        }

        [Given(@"Susie is on login screen")]
        public void GivenSusieIsOnLoginScreenFor()
        {
            NavigateToPage(_sharedContext.BaseUrl);
            _loginPage.IsLoginLogoDisplayed.Should().BeTrue();
        }

        [When(@"she logs in with blank username and password")]
        public void WhenSheLogsInWithBlankUsernameAndPassword()
        {
            _loginPage.ClickLogin();
        }

        [When(@"she logs in with blank password")]
        public void WhenSheLogsInWithBlankPassword(Table table)
        {
            var username = table.Rows[0][0];

            _loginPage.SetUsername(username);
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
        
        [Then(@"the error message ""(.+)"" will be displayed")]
        public void ThenTheErrorMessageWillBeDisplayed(string message)
        {
            _loginPage.ErrorMessage.Should().Be(message);
        }

        [Then(@"the homepage is displayed")]
        public void ThenTheHomepageIsDisplayed()
        {
            _homePage.IsHomeLinkDisplayed().Should().Be(true);
        }
        
        private void NavigateToPage(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }
    }
}
