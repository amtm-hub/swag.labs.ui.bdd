using BoDi;
using OpenQA.Selenium;
using SpecFlowProject1.Context;
using SpecFlowProject1.Drivers;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowProject1.Hooks
{
    [Binding]
    public sealed class CommonStepDefinitions
    {
        private readonly IObjectContainer _objectContainer;
        private IWebDriver _driver;
        private SharedContext _sharedContext;
        
        public CommonStepDefinitions(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }
        
        [BeforeScenario()]
        public void OpenBrowser()
        {
            _driver = ChromeDriver.GetDriver();
            _objectContainer.RegisterInstanceAs(_driver, dispose: true);
        }

        [BeforeScenario()]
        public void SetContext()
        {
            _sharedContext = new SharedContext();
            _objectContainer.RegisterInstanceAs(_sharedContext, dispose: true);
        }

        [AfterStep()]
        public void CheckOnServiceError()
        {
            var serviceErrorCtr = _driver.FindElements(By.XPath("//div[contains(@class,'k-window')]//span[.='Service Error']")).Count;
            if (serviceErrorCtr > 0) throw new Exception("Service Error is displayed");
        }

        [AfterScenario()]
        public void CloseBrowser()
        {
            _driver.Quit();
        }
    }
}
