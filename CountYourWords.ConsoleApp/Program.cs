using CountYourWords.Sorting;
using CountYourWords.WordProcessing;
using CountYourWords.WordProcessing.Summary;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CountYourWords.ConsoleApp;

internal class Program
{
    private const string InputFileName = "input.txt";
    private static readonly IHost _host = CreateHost();

    internal static void Main(string[] args)
    {
        var services = _host.Services.GetRequiredService<Services>();

        while (services.Reader.Read() is { } word)
        {
            services.Summary.Add(word);
        }

        WriteOutputToConsole(services);
    }

    private static void WriteOutputToConsole(Services services)
    {
        var wordFrequencies = services.Sorter.Sort(services.Summary.GetWordFrequencies());

        Console.WriteLine($"Number of words: {services.Summary.GetTotalWordCount()}");
        Console.WriteLine();

        foreach (var (word, frequency) in wordFrequencies)
        {
            Console.WriteLine($"{word}: {frequency}");
        }
    }

    private static IHost CreateHost() =>
        Host.CreateDefaultBuilder().ConfigureServices(ConfigureServices).Build();

    internal static void ConfigureServices(HostBuilderContext? context, IServiceCollection services) =>
        services
            .AddSingleton<Services>()
            .AddWordProcessingDependencies(InputFileName)
            .AddSortingDependencies<WordFrequency>();
}