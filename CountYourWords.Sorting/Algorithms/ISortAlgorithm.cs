namespace CountYourWords.Sorting.Algorithms;

public interface ISortAlgorithm<TElement> : ISorter<TElement>
{
    bool IsApplicable(TElement[] array);
}