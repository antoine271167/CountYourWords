namespace CountYourWords.Sorting.Algorithms;

internal interface ISortAlgorithm<TElement> : ISorter<TElement>
{
    bool IsApplicable(TElement[] array);
}