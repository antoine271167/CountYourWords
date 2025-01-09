using CountYourWords.WordProcessing.Filters;
using CountYourWords.WordProcessing.Readers;
using CountYourWords.WordProcessing.Summary;
using Microsoft.Extensions.DependencyInjection;

namespace CountYourWords.WordProcessing;

public static class DependencyInjection
{
    public static IServiceCollection AddWordProcessingDependencies(
        this IServiceCollection services, string inputFileName) =>
        services
            .AddSingleton<IComparer<WordFrequency>, WordFrequencyComparer>()
            .AddTransient<ITextSummary, TextSummary>()
            .AddSingleton<IWordFilter, WordFilter>()
            .AddTransient<TextReader>(_ => new StreamReader(inputFileName))
            .AddTransient<IWordFileReader, WordFileReader>()
            .AddTransient<IWordFilterReader>(provider => new WordFilterReader(
                provider.GetRequiredService<IWordFileReader>(),
                provider.GetRequiredService<IWordFilter>()));
}