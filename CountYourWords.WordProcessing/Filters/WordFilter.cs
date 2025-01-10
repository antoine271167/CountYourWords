namespace CountYourWords.WordProcessing.Filters;

internal class WordFilter : IWordFilter
{
    public bool IsAllowed(string word) => word.Any(char.IsLetter);
}