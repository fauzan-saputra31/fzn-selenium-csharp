using OpenQA.Selenium;

namespace FznSeleniumCsharp.Pages;

public class ComputerDatabasePage(IWebDriver driver) : BasePage(driver)
{
    private static By BtnAddNewComputerLocator => By.Id("add");
    private static By BtnCreateThisComputerLocator => By.XPath("//input[@value='Create this computer']");
    private static By DrpdwnCompanyLocator => By.Id("company");
    private static By TxCreateComputerSuccessLocator => By.XPath("//div[@class='alert-message warning']");
    private static By TxbxComputerNameLocator => By.Id("name");
    private static By TxbxDtDiscontinuedLocator => By.Id("discontinued");
    private static By TxbxDtIntroducedLocator => By.Id("introduced");
    
    public void AddNewComputer(string computerName, string computerDateIntroduced, string computerDateDiscontinued, string company)
    {
        Click(BtnAddNewComputerLocator);
        Type(TxbxComputerNameLocator, computerName);
        Type(TxbxDtIntroducedLocator, computerDateIntroduced);
        Type(TxbxDtDiscontinuedLocator, computerDateDiscontinued);
        SelectDropDownByText(DrpdwnCompanyLocator, company);
        Click(BtnCreateThisComputerLocator);
    }
    
    public bool IsComputerCreated(string computerName)
    {
        return GetText(TxCreateComputerSuccessLocator).Contains(computerName);
    }
    
}