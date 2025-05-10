using FznSeleniumCsharp.Utilities;
using OpenQA.Selenium;
using NUnit.Framework;

namespace FznSeleniumCsharp.Tests;

public class BaseTest
{
    protected IWebDriver Driver = null!;
    private readonly string _browser = ConfigReader.Get("browser");
    protected readonly string BaseUrlComputerDatabase = ConfigReader.Get("baseUrlComputerDatabase");

    [SetUp]
    public void SetUp()
    {
        Driver = WebDriverFactory.CreateWebDriver("chrome");
    }
    
    [TearDown]
    public void TearDown()
    {
        Driver.Quit();
    }
}