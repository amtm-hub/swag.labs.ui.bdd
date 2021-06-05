using FluentAssertions;
using FluentAssertions.Execution;
using OpenQA.Selenium;
using SpecFlowProject1.Context;
using SpecFlowProject1.Pages;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SpecFlowProject1.Steps
{
    [Binding]
    public sealed class HomeStepDefinitions
    {
        private readonly IWebDriver _driver;
        private readonly SharedContext _sharedContext;
        private readonly HomePage _page;
        private readonly LoginPage _loginPage;
        private IEnumerable<ProductPage> _products;

        public HomeStepDefinitions(IWebDriver driver, SharedContext sharedContext)
        {
            _driver = driver;
            _sharedContext = sharedContext;
            _page = new HomePage(driver);
            _loginPage = new LoginPage(driver);
        }

        [Given(@"Susie is on homepage")]
        public void GivenSusieIsOnHomepage()
        {
            NavigateToPage(_sharedContext.BaseUrl);
            _loginPage.IsLoginLogoDisplayed.Should().BeTrue();

            _loginPage.SetUsername(_sharedContext.SusieUsername);
            _loginPage.SetPassword(_sharedContext.SusiePassword);
            _loginPage.ClickLogin();

            _page.IsHomeLinkDisplayed().Should().BeTrue();
        }

        [When(@"she views information of products on grid")]
        public void WhenSheViewsInformationOfProductsOnGrid()
        {
            _products = _page.Products;
        }

        [Then(@"item name, item description and item price are displayed with Add to Cart option")]
        public void ThenItemNameItemDescriptionAndItemPriceAreDisplayedWithAddToCartOption()
        {
            foreach (var product in _products)
            {
                using (new AssertionScope())
                {
                    product.ItemImageSource.Should().Contain(".jpg");
                    product.ItemDescription.Should().Contain("$");
                    product.ItemPrice.Should().Contain("$");
                    product.IsAddToCartEnabled.Should().BeTrue();
                }
            }
        }

        private void NavigateToPage(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }
    }
}
