namespace CountYourWords.Sorting.Algorithms;

public class QuickSortAlgorithm<TElement>(IComparer<TElement> comparer) : ISortAlgorithm<TElement>
{
    public TElement[] Sort(TElement[] array) =>
        array.Length == 0 ? array : Sort(array, 0, array.Length - 1);

    public bool IsApplicable(TElement[] array) => true;

    private TElement[] Sort(TElement[] array, int leftIndex, int rightIndex)
    {
        var i = leftIndex;
        var j = rightIndex;
        var pivot = array[leftIndex];

        while (i <= j)
        {
            while (comparer.Compare(array[i], pivot) < 0)
            {
                i++;
            }

            while (comparer.Compare(array[j], pivot) > 0)
            {
                j--;
            }

            if (i <= j)
            {
                (array[i], array[j]) = (array[j], array[i]);
                i++;
                j--;
            }
        }

        if (leftIndex < j)
        {
            Sort(array, leftIndex, j);
        }

        if (i < rightIndex)
        {
            Sort(array, i, rightIndex);
        }

        return array;
    }
}