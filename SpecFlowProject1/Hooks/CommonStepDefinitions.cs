using BoDi;
using OpenQA.Selenium;
using SpecFlowProject1.Drivers;
using TechTalk.SpecFlow;

namespace SpecFlowProject1.Hooks
{
    [Binding]
    public sealed class CommonStepDefinitions
    {
        private readonly IObjectContainer _objectContainer;
        private IWebDriver _driver;

        public CommonStepDefinitions(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        [BeforeScenario()]
        public void OpenBrowser()
        {
            _driver = Browser.GetDriver();
            _objectContainer.RegisterInstanceAs<IWebDriver>(_driver);
        }

        [AfterScenario()]
        public void CloseBrowser()
        {
            _driver.Quit();
        }
    }
}
