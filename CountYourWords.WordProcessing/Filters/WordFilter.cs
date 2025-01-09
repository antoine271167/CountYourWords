namespace CountYourWords.WordProcessing.Filters;

public class WordFilter : IWordFilter
{
    public bool IsAllowed(string word) => word.Any(char.IsLetter);
}