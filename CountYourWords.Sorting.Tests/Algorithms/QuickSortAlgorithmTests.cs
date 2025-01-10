using CountYourWords.Sorting.Algorithms;

namespace CountYourWords.Sorting.Tests.Algorithms;

[TestFixture]
public class QuickSortAlgorithmTests
{
    private readonly IComparer<int> _comparer = Comparer<int>.Default;

    [Test]
    public void Sort_SortsArrayCorrectly()
    {
        // Arrange
        var sut = new QuickSortAlgorithm<int>(_comparer);
        var array = new[] { 3, 1, 4, 1, 5, 9, 2, 6, 5, 3, 5 };

        // Act
        var actual = sut.Sort(array);

        // Assert
        actual.Should().Equal(1, 1, 2, 3, 3, 4, 5, 5, 5, 6, 9);
    }

    [Test]
    public void Sort_EmptyArray_ReturnsEmptyArray()
    {
        // Arrange
        var sut = new QuickSortAlgorithm<int>(_comparer);
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
        var sut = new QuickSortAlgorithm<int>(_comparer);
        var array = new[] { 42 };

        // Act
        var actual = sut.Sort(array);

        // Assert
        actual.Should().Equal(42);
    }

    [Test]
    public void Sort_AlreadySortedArray_ReturnsSameArray()
    {
        // Arrange
        var sut = new QuickSortAlgorithm<int>(_comparer);
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
        var sut = new QuickSortAlgorithm<int>(_comparer);
        var array = new[] { 5, 4, 3, 2, 1 };

        // Act
        var actual = sut.Sort(array);

        // Assert
        actual.Should().Equal(1, 2, 3, 4, 5);
    }
}