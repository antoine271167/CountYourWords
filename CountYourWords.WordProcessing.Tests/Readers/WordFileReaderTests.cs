using CountYourWords.WordProcessing.Readers;
using FluentAssertions;

namespace CountYourWords.WordProcessing.Tests.Readers;

public class WordFileReaderTests
{
    [TestCase(0, "Word1")]
    [TestCase(1, "Word2")]
    [TestCase(2, "Word3")]
    [TestCase(3, "Word4")]
    [TestCase(4, "Word5")]
    [TestCase(5, "Word6")]
    public void Read_TextContainsWord_ShouldReturnWord(int wordIndex, string word)
    {
        // Arrange
        const string text = "Word1,Word2;Word3\nWord4\rWord5 Word6";

        using var reader = new StringReader(text);
        var sut = new WordFileReader(reader);

        // Act
        string? actual;

        do
        {
            actual = sut.Read();
        } while (wordIndex-- > 0);

        // Assert
        actual.Should().Be(word);
    }
}