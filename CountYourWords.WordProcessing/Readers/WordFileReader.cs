using System.Text;

namespace CountYourWords.WordProcessing.Readers;

public class WordFileReader(TextReader reader) : IWordFileReader
{
    private static readonly char[] _otherBoundaryChars = ['\n', '\n', '[', ']', '{', '}', '<', '>', '(', ')'];

    public string? Read()
    {
        var word = new StringBuilder();

        int c;
        while ((c = reader.Read()) != -1)
        {
            var character = (char)c;

            if (IsWordBoundary(character))
            {
                break;
            }

            if (char.IsControl(character))
            {
                continue;
            }

            word.Append(character);
        }

        var result = word.ToString();
        return c == -1 && result == string.Empty ? null : result;
    }

    private static bool IsWordBoundary(char character) =>
        char.IsWhiteSpace(character) ||
        char.IsSeparator(character) ||
        char.IsPunctuation(character) ||
        _otherBoundaryChars.Contains(character);
}