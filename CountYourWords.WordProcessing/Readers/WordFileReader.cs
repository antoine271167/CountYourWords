using System.Text;

namespace CountYourWords.WordProcessing.Readers;

internal class WordFileReader(TextReader reader) : IWordFileReader
{
    private static readonly char[] _otherBoundaryChars = ['[', ']', '{', '}', '<', '>', '(', ')'];

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

            word.Append(character);
        }

        var result = word.ToString();
        return c == -1 && result == string.Empty ? null : result;
    }

    private static bool IsWordBoundary(char character) =>
        char.IsWhiteSpace(character) ||
        char.IsSeparator(character) ||
        char.IsPunctuation(character) ||
        char.IsControl(character) ||
        _otherBoundaryChars.Contains(character);
}