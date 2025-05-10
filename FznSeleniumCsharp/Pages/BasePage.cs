using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace FznSeleniumCsharp.Pages;

public abstract class BasePage(IWebDriver driver)
{
    private readonly WebDriverWait _webDriverWait = new(driver, TimeSpan.FromSeconds(10));

    private IWebElement WaitForElementToBeVisible(By locator)
    {
        return _webDriverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
    }

    protected void Click(By locator)
    {
        WaitForElementToBeVisible(locator).Click();
    }
    
    protected string GetText(By locator)
    {
        return WaitForElementToBeVisible(locator).Text;
    }
    
    protected void SelectDropDownByIndex(By locator, int index)
    {
        var dropdownElement = WaitForElementToBeVisible(locator);
        var selectElement = new SelectElement(dropdownElement);
        selectElement.SelectByIndex(index);
    }
    
    protected void SelectDropDownByText(By locator, string text)
    {
        var dropdownElement = WaitForElementToBeVisible(locator);
        var selectElement = new SelectElement(dropdownElement);
        selectElement.SelectByText(text);
    }
    
    protected void SelectDropDownByValue(By locator, string value)
    {
        var dropdownElement = WaitForElementToBeVisible(locator);
        var selectElement = new SelectElement(dropdownElement);
        selectElement.SelectByValue(value);
    }
    
    protected void Type(By locator, string text)
    {
        var element = WaitForElementToBeVisible(locator);
        element.Clear();
        element.SendKeys(text);
    }

}