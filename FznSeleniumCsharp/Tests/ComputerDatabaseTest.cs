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
        computerDatabasePage.AddNewComputer(
            computerName: name,
            computerDateIntroduced: introduced,
            computerDateDiscontinued: discontinued,
            company: company
            );
        Assert.AreEqual(computerDatabasePage.IsComputerCreated(computerName: name), true);
    }
}