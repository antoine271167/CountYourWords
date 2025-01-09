namespace CountYourWords.Sorting.Algorithms;

public class BubbleSortAlgorithm<TElement>(IComparer<TElement> comparer) : ISortAlgorithm<TElement>
{
    private const int MaxArrayLength = 10;

    public TElement[] Sort(TElement[] array)
    {
        for (var j = 0; j <= array.Length - 2; j++)
        {
            for (var i = 0; i <= array.Length - 2; i++)
            {
                if (comparer.Compare(array[i], array[i + 1]) > 0)
                {
                    (array[i + 1], array[i]) = (array[i], array[i + 1]);
                }
            }
        }

        return array;
    }

    public bool IsApplicable(TElement[] array) => array.Length <= MaxArrayLength;
}