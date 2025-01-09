using CountYourWords.WordProcessing.Filters;
using FluentAssertions;

namespace CountYourWords.WordProcessing.Tests.Filters;

public class WordFilterTests
{
    [TestCase("Valid")]
    [TestCase("love4u")]
    [TestCase("mail@address.nl")]
    public void IsAllowed_ContainsValidChars_ShouldReturnTrue(string word)
    {
        // Arrange
        var sut = new WordFilter();

        // Act
        var actual = sut.IsAllowed(word);

        // Assert
        actual.Should().BeTrue();
    }

    [TestCase("##")]
    [TestCase("@")]
    [TestCase("123")]
    [TestCase("")]
    public void IsAllowed_AllCharsAreInvalid_ShouldReturnFalse(string word)
    {
        // Arrange
        var sut = new WordFilter();

        // Act
        var actual = sut.IsAllowed(word);

        // Assert
        actual.Should().BeFalse();
    }
}