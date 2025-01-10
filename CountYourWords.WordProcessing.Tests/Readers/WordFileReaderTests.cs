using CountYourWords.WordProcessing.Readers;

namespace CountYourWords.WordProcessing.Tests.Readers;

public class WordFileReaderTests
{
    [Test]
    public void Read_ShouldReturnNull_WhenReaderIsEmpty()
    {
        // Arrange
        using var reader = new StringReader(string.Empty);
        var sut = new WordFileReader(reader);

        // Act
        var actual = sut.Read();

        // Assert
        actual.Should().BeNull();
    }

    [Test]
    public void Read_ShouldReturnWord_WhenReaderContainsSingleWord()
    {
        // Arrange
        using var reader = new StringReader("Word1");
        var sut = new WordFileReader(reader);

        // Act
        var actual = sut.Read();

        // Assert
        actual.Should().Be("Word1");
    }

    [Test]
    public void Read_TextWithVariousSeparators_ShouldReturnAllWords()
    {
        // Arrange
        const string text = "Word1,Word2;Word3\nWord4\rWord5\u0001Word6 Word7[Word8";

        using var reader = new StringReader(text);
        var sut = new WordFileReader(reader);

        // Act
        var words = new List<string?>();

        string? word;

        do
        {
            word = sut.Read();
            if (word != null)
            {
                words.Add(word);
            }
        } while (word != null);

        // Assert
        string.Join(" ", words).Should().Be("Word1 Word2 Word3 Word4 Word5 Word6 Word7 Word8");
    }
}