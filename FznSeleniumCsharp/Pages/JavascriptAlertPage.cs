using OpenQA.Selenium;

namespace FznSeleniumCsharp.Pages;

public class JavascriptAlertPage(IWebDriver driver) : BasePage(driver)
{
    private readonly IWebDriver _driver = driver;
    private static By BtnJsAlertLocator => By.XPath("//button[normalize-space()='Click for JS Alert']");
    private static By BtnJsConfirmLocator => By.XPath("//button[normalize-space()='Click for JS Confirm']");
    private static By BtnJsPromptLocator => By.XPath("//button[normalize-space()='Click for JS Prompt']");
    private static By TxResultLocator => By.Id("result");

    public void ClickAndConfirmAlert()
    {
        Click(BtnJsAlertLocator);
        _driver.SwitchTo().Alert().Accept();
    }
    
    public void ClickAndConfirmAlertOption()
    {
        Click(BtnJsConfirmLocator);
        _driver.SwitchTo().Alert().Accept();
    }
    
    public void ClickAndDismissAlertOption()
    {
        Click(BtnJsConfirmLocator);
        _driver.SwitchTo().Alert().Dismiss();
    }

    public void ClickAndEnterMessageAlertPrompt(string prompt)
    {
        Click(BtnJsPromptLocator);
        _driver.SwitchTo().Alert().SendKeys(prompt);
        _driver.SwitchTo().Alert().Accept();
    }

    public string GetResult()
    {
        return GetText(TxResultLocator);
    }
}