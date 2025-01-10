using CountYourWords.WordProcessing.Summary;

namespace CountYourWords.WordProcessing.Tests.Summary;

public class TextSummaryTests
{
    [Test]
    public void Add_SingleWord_IncreasesTotalWordCount()
    {
        // Arrange
        var sut = new TextSummary();

        // Act
        sut.Add("word1");

        // Assert
        sut.GetTotalWordCount().Should().Be(1);
    }

    [Test]
    public void Add_MultipleWords_IncreasesTotalWordCount()
    {
        // Arrange
        var sut = new TextSummary();

        // Act
        sut.Add("word1");
        sut.Add("word2");

        // Assert
        sut.GetTotalWordCount().Should().Be(2);
    }

    [Test]
    public void Add_SameWordMultipleTimes_IncreasesWordFrequency()
    {
        // Arrange
        var sut = new TextSummary();

        // Act
        sut.Add("word1");
        sut.Add("word1");

        // Assert
        sut.GetWordFrequencies().Should().ContainSingle()
            .Which.Should().BeEquivalentTo(new WordFrequency("word1", 2));
    }

    [Test]
    public void GetWordFrequencies_ReturnsCorrectFrequencies()
    {
        // Arrange
        var sut = new TextSummary();
        sut.Add("word1");
        sut.Add("word2");
        sut.Add("word1");

        // Act
        var act = sut.GetWordFrequencies();

        // Assert
        act.Should().HaveCount(2);
        act.Should().ContainEquivalentOf(new WordFrequency("word1", 2));
        act.Should().ContainEquivalentOf(new WordFrequency("word2", 1));
    }

    [Test]
    public void Add_WordWithDifferentCasing_TreatsAsSameWord()
    {
        // Arrange
        var sut = new TextSummary();

        // Act
        sut.Add("Word1");
        sut.Add("word1");

        // Assert
        sut.GetWordFrequencies().Should().ContainSingle()
            .Which.Should().BeEquivalentTo(new WordFrequency("word1", 2));
    }
}