using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SpecFlowProject1.Drivers
{
    public static class ChromeDriver
    {
        public static IWebDriver GetDriver()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            return new OpenQA.Selenium.Chrome.ChromeDriver(options);
        }
    }
}