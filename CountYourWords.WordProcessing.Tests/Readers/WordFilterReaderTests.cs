using CountYourWords.WordProcessing.Filters;
using CountYourWords.WordProcessing.Readers;

namespace CountYourWords.WordProcessing.Tests.Readers;

public class WordFilterReaderTests
{
    [Test]
    public void Read_WhenWordIsAllowed_ReturnsWord()
    {
        // Arrange
        var reader = new Mock<IWordReader>();
        reader.SetupSequence(r => r.Read())
            .Returns("word1")
            .Returns("word2")
            .Returns("word3")
            .Returns((string?)null);

        var filter = new Mock<IWordFilter>();
        filter.Setup(f => f.IsAllowed("word1")).Returns(true);
        filter.Setup(f => f.IsAllowed("word2")).Returns(false);
        filter.Setup(f => f.IsAllowed("word3")).Returns(true);

        var sut = new WordFilterReader(reader.Object, filter.Object);

        // Act
        var actual = new List<string>();
        while (sut.Read() is { } word)
        {
            actual.Add(word);
        }

        // Assert
        actual.Should().Contain("word1");
        actual.Should().NotContain("word2");
        actual.Should().Contain("word3");
    }
}