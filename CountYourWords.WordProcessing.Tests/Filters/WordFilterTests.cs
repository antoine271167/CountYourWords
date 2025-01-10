using CountYourWords.WordProcessing.Filters;

namespace CountYourWords.WordProcessing.Tests.Filters;

public class WordFilterTests
{
    [TestCase("Valid", true)]
    [TestCase("love4u", true)]
    [TestCase("mail@address.nl", true)]
    [TestCase("##", false)]
    [TestCase("@", false)]
    [TestCase("123", false)]
    [TestCase("", false)]
    public void IsAllowed_ShouldReturnProperValue_ForVariousInputValues(string word, bool isAllowed)
    {
        // Arrange
        var sut = new WordFilter();

        // Act
        var actual = sut.IsAllowed(word);

        // Assert
        actual.Should().Be(isAllowed);
    }
}