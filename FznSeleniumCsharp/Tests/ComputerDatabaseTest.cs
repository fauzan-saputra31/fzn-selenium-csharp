using System.Collections;
using FznSeleniumCsharp.Pages;
using FznSeleniumCsharp.Utilities;
using NUnit.Framework;

namespace FznSeleniumCsharp.Tests;

public class ComputerDatabaseTest : BaseTest
{
    public static IEnumerable ComputerDatabaseTestCases
    {
        get
        {
            foreach (var data in TestDataReader.GetComputerDatabaseTestData())
            {
                yield return new TestCaseData(data.Name, data.Introduced, data.Discontinued, data.Company);
            }
        }
    }
    
    [Test, TestCaseSource(nameof(ComputerDatabaseTestCases))]
    public void SuccessfulCreateNewComputer(string name, string introduced, string discontinued, string company)
    {
        Driver.Navigate().GoToUrl(BaseUrlComputerDatabase);
        var computerDatabasePage = new ComputerDatabasePage(Driver);
        computerDatabasePage.AddNew(
            name: name,
            introduced: introduced,
            discontinued: discontinued,
            company: company
            );
        Assert.AreEqual(computerDatabasePage.IsCreated(name: name), true);
    }
    
    [Test]
    public void SuccessfulEditComputer()
    {
        Driver.Navigate().GoToUrl(BaseUrlComputerDatabase);
        var computerDatabasePage = new ComputerDatabasePage(Driver);
        computerDatabasePage.Edit(
            computer: "Ace",
            name: "new name",
            introduced: "1900-01-01",
            discontinued: "2099-12-31",
            company: "Apple Inc."
            );
        Assert.AreEqual(computerDatabasePage.IsUpdated(name: "new name"), true);
    }
    
    [Test]
    public void SuccessfulDeleteComputer()
    {
        Driver.Navigate().GoToUrl(BaseUrlComputerDatabase);
        var computerDatabasePage = new ComputerDatabasePage(Driver);
        computerDatabasePage.Delete(name: "ACE");
        Assert.AreEqual(computerDatabasePage.IsDeleted("ACE"), true);
    }
}