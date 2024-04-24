using Microsoft.Extensions.Configuration;
using SonarAnalyzer.Console;

var names = new List<string> { "Bob", "John", "Sarah", "Brad", "Ben" };
var configuration = GetConfiguration();

// Find over FirstOrDefault
var firstNameMatch = names.Find(x => x.StartsWith("b", StringComparison.CurrentCultureIgnoreCase));

Console.WriteLine(firstNameMatch);

//recursions should not be infinite
void RecursiveMethod(int index)
{
    if (index > 10)
    {
        return;
    }

    RecursiveMethod(index);
}

var outputPath = configuration["Settings:OutputPath"] ?? string.Empty;
var resourceHolder = new ResourceHolder();

resourceHolder.WriteToFile($"{outputPath}\\testFile.txt", "wow, did this work?!? 123");


IConfiguration GetConfiguration()
{
    var builder = new ConfigurationBuilder();
    builder.SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

    return builder.Build();
}