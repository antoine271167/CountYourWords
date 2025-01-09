namespace CountYourWords.WordProcessing.Summary;

public interface ITextSummary
{
    void Add(string word);
    WordFrequency[] GetWordFrequencies();
    int GetTotalWordCount();
}