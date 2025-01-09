using CountYourWords.Sorting;
using CountYourWords.WordProcessing;
using CountYourWords.WordProcessing.Readers;
using CountYourWords.WordProcessing.Summary;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CountYourWords.ConsoleApp;

internal class Program
{
    private const string InputFileName = "input.txt";
    private static readonly IHost _host = CreateHostBuilder().Build();

    internal static void Main(string[] args)
    {
        var readerService = _host.Services.GetRequiredService<IWordFilterReader>();
        var summaryService = _host.Services.GetRequiredService<ITextSummary>();

        while (readerService.Read() is { } word)
        {
            summaryService.Add(word);
        }

        WriteOutputToConsole(summaryService);
    }

    private static void WriteOutputToConsole(ITextSummary summary)
    {
        var sorter = _host.Services.GetRequiredService<ISorter<WordFrequency>>();

        var wordFrequencies = sorter.Sort(summary.GetWordFrequencies());

        Console.WriteLine($"Number of words: {summary.GetTotalWordCount()}");
        Console.WriteLine();

        foreach (var (word, frequency) in wordFrequencies)
        {
            Console.WriteLine($"{word}: {frequency}");
        }
    }

    private static IHostBuilder CreateHostBuilder() =>
        Host.CreateDefaultBuilder([]).ConfigureServices((_, services) => services
            .AddWordProcessingDependencies(InputFileName)
            .AddSortingDependencies<WordFrequency>());
}