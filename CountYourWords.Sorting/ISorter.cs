namespace CountYourWords.Sorting;

public interface ISorter<TElement>
{
    TElement[] Sort(TElement[] array);
}