using CountYourWords.WordProcessing.Filters;

namespace CountYourWords.WordProcessing.Readers;

public class WordFilterReader(IWordReader reader, IWordFilter filter) : IWordFilterReader
{
    public string? Read()
    {
        string? word;

        do
        {
            word = reader.Read();
        } while (word != null && !filter.IsAllowed(word));

        return word;
    }
}