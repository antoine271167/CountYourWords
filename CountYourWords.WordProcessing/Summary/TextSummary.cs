namespace CountYourWords.WordProcessing.Summary;

public class TextSummary : ITextSummary
{
    private readonly Dictionary<string, int> _wordCount = new();
    private int _totalWordCount;

    public void Add(string word)
    {
        var wordLower = word.ToLowerInvariant();
        if (!_wordCount.TryAdd(wordLower, 1))
        {
            _wordCount[wordLower]++;
        }

        _totalWordCount++;
    }

    public WordFrequency[] GetWordFrequencies() =>
        _wordCount.Select(kvp => new WordFrequency(kvp.Key, kvp.Value)).ToArray();

    public int GetTotalWordCount() => _totalWordCount;
}