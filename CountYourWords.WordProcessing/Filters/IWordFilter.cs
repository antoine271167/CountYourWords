namespace CountYourWords.WordProcessing.Filters;

public interface IWordFilter
{
    bool IsAllowed(string word);
}