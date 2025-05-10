using Newtonsoft.Json;
using FznSeleniumCsharp.DataModels;

namespace FznSeleniumCsharp.Utilities;

public class TestDataReader
{
    public static IEnumerable<ComputerDatabaseData> GetComputerDatabaseTestData()
    {
        var jsonPath = Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "TestData", "ComputerDatabaseData.json");
        var json = File.ReadAllText(jsonPath);
        return JsonConvert.DeserializeObject<List<ComputerDatabaseData>>(json) ?? throw new InvalidOperationException();
    }
}