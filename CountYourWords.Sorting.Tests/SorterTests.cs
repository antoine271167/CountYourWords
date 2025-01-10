using CountYourWords.Sorting.Algorithms;

namespace CountYourWords.Sorting.Tests;

public class SorterTests
{
    private Mock<ISortAlgorithm<int>> _mockAlgorithm0;
    private Mock<ISortAlgorithm<int>> _mockAlgorithm1;
    private List<ISortAlgorithm<int>> _algorithms;
    private Sorter<int> _sut;

    [SetUp]
    public void SetUp()
    {
        _mockAlgorithm0 = new Mock<ISortAlgorithm<int>>();
        _mockAlgorithm1 = new Mock<ISortAlgorithm<int>>();
        _algorithms = [_mockAlgorithm0.Object, _mockAlgorithm1.Object];
        _sut = new Sorter<int>(_algorithms);
    }

    [Test]
    public void Sort_ShouldUseApplicableAlgorithm_WhenAlgorithmIsApplicable()
    {
        // Arrange
        var array = new[] { 3, 1, 2 };
        var sortedArray = new[] { 1, 2, 3 };
        _mockAlgorithm0.Setup(a => a.IsApplicable(array)).Returns(false);
        _mockAlgorithm1.Setup(a => a.IsApplicable(array)).Returns(true);
        _mockAlgorithm1.Setup(a => a.Sort(array)).Returns(sortedArray);

        // Act
        var actual = _sut.Sort(array);

        // Assert
        actual.Should().BeEquivalentTo(sortedArray);
        _mockAlgorithm0.Verify(a => a.Sort(array), Times.Never);
        _mockAlgorithm1.Verify(a => a.Sort(array), Times.Once);
    }

    [Test]
    public void Sort_ShouldThrowInvalidOperationException_WhenNoAlgorithmIsApplicable()
    {
        // Arrange
        var array = new[] { 3, 1, 2 };
        _mockAlgorithm0.Setup(a => a.IsApplicable(array)).Returns(false);
        _mockAlgorithm1.Setup(a => a.IsApplicable(array)).Returns(false);

        // Act
        var actual = () => _sut.Sort(array);

        // Assert
        actual.Should().Throw<InvalidOperationException>().WithMessage("No applicable algorithm found.");
        _mockAlgorithm0.Verify(a => a.Sort(It.IsAny<int[]>()), Times.Never);
    }
}