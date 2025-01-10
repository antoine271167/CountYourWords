using CountYourWords.Sorting;
using CountYourWords.WordProcessing.Readers;
using CountYourWords.WordProcessing.Summary;

namespace CountYourWords.ConsoleApp;

public class Services(IWordFilterReader reader, ITextSummary summary, ISorter<WordFrequency> sorter)
{
    public IWordFilterReader Reader { get; } = reader;
    public ITextSummary Summary { get; } = summary;
    public ISorter<WordFrequency> Sorter { get; } = sorter;
}