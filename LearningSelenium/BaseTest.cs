using LearningSelenium.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V127.CacheStorage;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace LearningSelenium
{
    internal class BaseTest
    {
        private IWebDriver driver;

        protected IWebDriver GetDriver()
        {
            return driver;
        }

        [SetUp]
        public void Setup()
        {
            driver = CreateDriver(ConfigurationProvider.Configuratrion["browser"]);
            driver.Manage().Window.Size = new System.Drawing.Size(1920, 1080);
            driver.Navigate().GoToUrl("http://localhost:4200");
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }

        private IWebDriver CreateDriver(string browserName)
        {
            switch (browserName.ToLowerInvariant())
            {
                case "chrome":
                    return new ChromeDriver();
                case "firefox":
                    return new FirefoxDriver();
                case "edge":
                    return new EdgeDriver();
                default:
                    throw new Exception("Provided browser is not supported!");
            }
        }
    }
}
