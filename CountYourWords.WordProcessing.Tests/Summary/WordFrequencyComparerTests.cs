using CountYourWords.WordProcessing.Summary;
using FluentAssertions;

namespace CountYourWords.WordProcessing.Tests.Summary;

public class WordFrequencyComparerTests
{
    [Test]
    public void Compare_BothWordsAreEqual_ReturnsZero()
    {
        // Arrange
        var word1 = new WordFrequency("word", 1);
        var word2 = new WordFrequency("word", 2);
        var sut = new WordFrequencyComparer();

        // Act
        var actual = sut.Compare(word1, word2);

        // Assert
        actual.Should().Be(0);
    }

    [Test]
    public void Compare_FirstWordIsLessThanSecondWord_ReturnsNegative()
    {
        // Arrange
        var word1 = new WordFrequency("word1", 1);
        var word2 = new WordFrequency("word2", 2);
        var sut = new WordFrequencyComparer();

        // Act
        var actual = sut.Compare(word1, word2);

        // Assert
        actual.Should().BeLessThan(0);
    }

    [Test]
    public void Compare_FirstWordIsGreaterThanSecondWord_ReturnsPositive()
    {
        // Arrange
        var word1 = new WordFrequency("word2", 1);
        var word2 = new WordFrequency("word1", 2);
        var sut = new WordFrequencyComparer();

        // Act
        var actual = sut.Compare(word1, word2);

        // Assert
        actual.Should().BeGreaterThan(0);
    }

    [Test]
    public void Compare_FirstWordIsNull_ThrowsArgumentNullException()
    {
        // Arrange
        var word2 = new WordFrequency("word1", 2);
        var sut = new WordFrequencyComparer();

        // Act
        var actual = () => sut.Compare(null, word2);

        // Assert
        actual.Should().Throw<ArgumentNullException>().WithParameterName("x");
    }

    [Test]
    public void Compare_SecondWordIsNull_ThrowsArgumentNullException()
    {
        // Arrange
        var word1 = new WordFrequency("word1", 1);
        var sut = new WordFrequencyComparer();

        // Act
        var actual = () => sut.Compare(word1, null);

        // Assert
        actual.Should().Throw<ArgumentNullException>().WithParameterName("y");
    }
}