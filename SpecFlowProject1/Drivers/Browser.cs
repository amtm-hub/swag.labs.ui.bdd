using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SpecFlowProject1.Drivers
{
    public static class Browser
    {
        public static IWebDriver GetDriver()
        {
            return new ChromeDriver();
        }
    }
}