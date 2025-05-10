using Microsoft.Extensions.Configuration;

namespace FznSeleniumCsharp.Utilities;

public static class ConfigReader
{
    private static readonly IConfigurationRoot Configuration;

    static ConfigReader()
    {
        var projectRoot = Path.Combine(AppContext.BaseDirectory, "..", "..", "..");
        Console.WriteLine("Project root path: " + projectRoot);
        var builder = new ConfigurationBuilder()
            .SetBasePath(projectRoot ?? throw new InvalidOperationException()) 
            .AddJsonFile("appsettings.json");
        
        Configuration = builder.Build();
    }

    public static string Get(string key)
    {
        return Configuration[$"TestSettings:{key}"] ?? throw new InvalidOperationException();
    }
}