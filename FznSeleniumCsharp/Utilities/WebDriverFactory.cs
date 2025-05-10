using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Safari;

namespace FznSeleniumCsharp.Utilities;

public static class WebDriverFactory
{
    public static IWebDriver CreateWebDriver(string browser = "chrome")
    {
        browser = browser.ToLower();
        IWebDriver driver;

        switch (browser)
        {
            case "chrome":
                var chromeOptions = new ChromeOptions();
                driver = new ChromeDriver(chromeOptions);
                break;
            case "firefox":
                var firefoxOptions = new FirefoxOptions();
                driver = new FirefoxDriver(firefoxOptions);
                break;
            case "safari":
                var safariOptions = new SafariOptions();
                driver = new SafariDriver(safariOptions);
                break;
            case "edge":
                var edgeOptions = new EdgeOptions();
                driver = new EdgeDriver(edgeOptions);
                break;
            default:
                throw new Exception("Browser not supported");
        }

        return driver;
    }
}