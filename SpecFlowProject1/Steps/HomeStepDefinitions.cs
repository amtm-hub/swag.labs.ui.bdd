using FluentAssertions;
using FluentAssertions.Execution;
using OpenQA.Selenium;
using SpecFlowProject1.Context;
using SpecFlowProject1.Pages;
using System.Collections.Generic;
using System.Linq;
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
        private readonly InventoryPage _inventoryPage;

        public HomeStepDefinitions(IWebDriver driver, SharedContext sharedContext)
        {
            _driver = driver;
            _sharedContext = sharedContext;
            _page = new HomePage(driver);
            _loginPage = new LoginPage(driver);
            _inventoryPage = new InventoryPage(driver);
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

        [When(@"she clicks on a product on grid")]
        public void WhenSheClicksOnAProductOnGrid()
        {
            _page.Products.First().Click();
        }

        [When(@"she clicks on Sort dropdown")]
        public void WhenSheClicksOnSortDropdown()
        {
            _page.ClickSort();
        }

        [Then(@"the grid displays item image, item name, item description and item price with Add to Cart option")]
        public void ThenTheGridDisplaysItemImageItemNameItemDescriptionAndItemPriceWithAddToCartOption()
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

        [Then(@"the page displays item image, item name, item description and item price with Add to Cart option")]
        public void ThenThePageDisplaysItemImageItemNameItemDescriptionAndItemPriceWithAddToCartOption()
        {
            using (new AssertionScope())
            {
                _inventoryPage.ImageSource.Should().Contain(".jpg");
                _inventoryPage.Name.Should().NotBeNullOrEmpty();
                _inventoryPage.Description.Should().NotBeNullOrEmpty();
                _inventoryPage.Price.Should().Contain("$");
                _inventoryPage.IsAddToCartEnabled.Should().BeTrue();
            }
        }

        [Then(@"she will see the following options")]
        public void ThenSheWillSeeTheFollowingOptions(Table table)
        {
            var expValues = table.Rows.Select(value => value["options"]).ToList();
            _page.SortOptions().Should().BeEquivalentTo(expValues);
        }

        private void NavigateToPage(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }
    }
}
