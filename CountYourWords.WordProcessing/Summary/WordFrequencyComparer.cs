namespace CountYourWords.WordProcessing.Summary;

public class WordFrequencyComparer : IComparer<WordFrequency>
{
    public int Compare(WordFrequency? x, WordFrequency? y)
    {
        if (x == null)
        {
            throw new ArgumentNullException(nameof(x));
        }

        if (y == null)
        {
            throw new ArgumentNullException(nameof(y));
        }

        return string.Compare(x.Word, y.Word, StringComparison.InvariantCultureIgnoreCase);
    }
}