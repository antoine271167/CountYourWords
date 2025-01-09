using CountYourWords.Sorting.Algorithms;
using Microsoft.Extensions.DependencyInjection;

namespace CountYourWords.Sorting;

public static class DependencyInjection
{
    public static IServiceCollection AddSortingDependencies<TElement>(this IServiceCollection services) =>
        services
            .AddSingleton<ISortAlgorithm<TElement>, BubbleSortAlgorithm<TElement>>()
            .AddSingleton<ISortAlgorithm<TElement>, QuickSortAlgorithm<TElement>>()
            .AddSingleton<ISorter<TElement>, Sorter<TElement>>();
}