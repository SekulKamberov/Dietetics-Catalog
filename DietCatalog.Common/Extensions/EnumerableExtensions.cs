namespace DietCatalog.Common.Extensions
{
    using System.Collections.Generic;

    public static class EnumerableExtensions
    {
        public static ISet<T> ToHashSet<T>(this IEnumerable<T> enumerable)
            => new HashSet<T>(enumerable);
    }
}
