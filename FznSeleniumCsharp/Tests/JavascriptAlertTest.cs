using FznSeleniumCsharp.Pages;
using NUnit.Framework;

namespace FznSeleniumCsharp.Tests;

public class JavascriptAlertTest : BaseTest
{
    [Test]
    public void JsAlertTest()
    {
        Driver.Navigate().GoToUrl(BaseUrlJavascriptAlert);
        var javascriptAlertPage = new JavascriptAlertPage(Driver);
        javascriptAlertPage.ClickAndConfirmAlert();
        Assert.AreEqual(javascriptAlertPage.GetResult(), "You successfully clicked an alert");
    }
    
    [Test]
    public void JsAlertConfirmTest()
    {
        Driver.Navigate().GoToUrl(BaseUrlJavascriptAlert);
        var javascriptAlertPage = new JavascriptAlertPage(Driver);
        javascriptAlertPage.ClickAndConfirmAlertOption();
        Assert.AreEqual(javascriptAlertPage.GetResult(), "You clicked: Ok");
        javascriptAlertPage.ClickAndDismissAlertOption();
        Assert.AreEqual(javascriptAlertPage.GetResult(), "You clicked: Cancel");
    }

    [Test]
    public void JsAlertPromptTest()
    {
        Driver.Navigate().GoToUrl(BaseUrlJavascriptAlert);
        var javascriptAlertPage = new JavascriptAlertPage(Driver);
        javascriptAlertPage.ClickAndEnterMessageAlertPrompt(prompt: "TEST AUTOMATION");
        Assert.AreEqual(javascriptAlertPage.GetResult(), "You entered: TEST AUTOMATION");
    }
}