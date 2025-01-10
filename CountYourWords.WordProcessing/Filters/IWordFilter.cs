namespace CountYourWords.WordProcessing.Filters;

internal interface IWordFilter
{
    bool IsAllowed(string word);
}