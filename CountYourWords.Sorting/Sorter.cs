using CountYourWords.Sorting.Algorithms;

namespace CountYourWords.Sorting;

public class Sorter<TElement>(IEnumerable<ISortAlgorithm<TElement>> algorithms) : ISorter<TElement>
{
    public TElement[] Sort(TElement[] array)
    {
        // Pick ths algorithm that is most suitable for the given array as
        // bubble sort slightly faster than quicksort for small arrays.
        var algorithm = algorithms.FirstOrDefault(a => a.IsApplicable(array));
        if (algorithm is null)
        {
            throw new InvalidOperationException("No applicable algorithm found.");
        }

        return algorithm.Sort(array);
    }
}