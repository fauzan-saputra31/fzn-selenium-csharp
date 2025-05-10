using OpenQA.Selenium;

namespace FznSeleniumCsharp.Pages;

public class ComputerDatabasePage(IWebDriver driver) : BasePage(driver)
{
    private static By BtnAddNewLocator => By.Id("add");
    private static By BtnCreateLocator => By.XPath("//input[@value='Create this computer']");
    private static By BtnSaveLocator => By.XPath("//input[@value='Save this computer']");
    private static By BtnSubmitSearchLocator => By.Id("searchsubmit");
    private static By DrpdwnCompanyLocator => By.Id("company");
    private static By TxCreateSuccessLocator => By.XPath("//div[@class='alert-message warning']");
    private static By TxNameLinkLocator(string text) => By.XPath($"(//a[contains(text(), '{text}')])[1]");
    private static By TxbxNameLocator => By.Id("name");
    private static By TxbxDtDiscontinuedLocator => By.Id("discontinued");
    private static By TxbxDtIntroducedLocator => By.Id("introduced");
    private static By TxbxSearchLocator => By.Id("searchbox");
    
    public void AddNew(string name, string introduced, string discontinued, string company)
    {
        Click(BtnAddNewLocator);
        Type(TxbxNameLocator, name);
        Type(TxbxDtIntroducedLocator, introduced);
        Type(TxbxDtDiscontinuedLocator, discontinued);
        SelectDropDownByText(DrpdwnCompanyLocator, company);
        Click(BtnCreateLocator);
    }
    
    public void Edit(string computer, string name, string introduced, string discontinued, string company)
    {
        Click(TxNameLinkLocator(computer));
        Type(TxbxNameLocator, name);
        Type(TxbxDtIntroducedLocator, introduced);
        Type(TxbxDtDiscontinuedLocator, discontinued);
        SelectDropDownByText(DrpdwnCompanyLocator, company);
        Click(BtnSaveLocator);
    }
    
    public void FilterByName(string name)
    {
        Type(TxbxSearchLocator, name);
        Click(BtnSubmitSearchLocator);
    }
    
    public bool IsCreatedOrUpdated(string name)
    {
        return GetText(TxCreateSuccessLocator).Contains(name);
    }
    
}