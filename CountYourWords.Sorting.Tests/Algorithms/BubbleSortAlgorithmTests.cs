using CountYourWords.Sorting.Algorithms;
using FluentAssertions;

namespace CountYourWords.Sorting.Tests.Algorithms;

public class BubbleSortAlgorithmTests
{
    private readonly IComparer<int> _comparer = Comparer<int>.Default;

    [Test]
    public void Sort_SortsArrayCorrectly()
    {
        // Arrange
        var sut = new BubbleSortAlgorithm<int>(_comparer);
        var array = new[] { 5, 3, 8, 4, 2 };

        // Act
        var actual = sut.Sort(array);

        // Assert
        actual.Should().Equal(2, 3, 4, 5, 8);
    }

    [Test]
    public void Sort_EmptyArray_ReturnsEmptyArray()
    {
        // Arrange
        var sut = new BubbleSortAlgorithm<int>(_comparer);
        var array = Array.Empty<int>();

        // Act
        var actual = sut.Sort(array);

        // Assert
        actual.Should().BeEmpty();
    }

    [Test]
    public void Sort_SingleElementArray_ReturnsSameArray()
    {
        // Arrange
        var sut = new BubbleSortAlgorithm<int>(_comparer);
        var array = new[] { 1 };

        // Act
        var actual = sut.Sort(array);

        // Assert
        actual.Should().Equal(1);
    }

    [Test]
    public void Sort_AlreadySortedArray_ReturnsSameArray()
    {
        // Arrange
        var sut = new BubbleSortAlgorithm<int>(_comparer);
        var array = new[] { 1, 2, 3, 4, 5 };

        // Act
        var actual = sut.Sort(array);

        // Assert
        actual.Should().Equal(1, 2, 3, 4, 5);
    }

    [Test]
    public void Sort_ReverseSortedArray_SortsArrayCorrectly()
    {
        // Arrange
        var sut = new BubbleSortAlgorithm<int>(_comparer);
        var array = new[] { 5, 4, 3, 2, 1 };

        // Act
        var actual = sut.Sort(array);

        // Assert
        actual.Should().Equal(1, 2, 3, 4, 5);
    }

    [Test]
    public void IsApplicable_ArrayLengthLessThanOrEqualToMaxArrayLength_ReturnsTrue()
    {
        // Arrange
        var sut = new BubbleSortAlgorithm<int>(_comparer);
        var array = new int[10];

        // Act
        var actual = sut.IsApplicable(array);

        // Assert
        actual.Should().BeTrue();
    }

    [Test]
    public void IsApplicable_ArrayLengthGreaterThanMaxArrayLength_ReturnsFalse()
    {
        // Arrange
        var sut = new BubbleSortAlgorithm<int>(_comparer);
        var array = new int[11];

        // Act
        var actual = sut.IsApplicable(array);

        // Assert
        actual.Should().BeFalse();
    }
}