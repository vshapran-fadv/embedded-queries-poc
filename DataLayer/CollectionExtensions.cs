using System.Collections.Generic;
using System.Linq;

namespace DataLayer
{
    public static class CollectionExtensions
    {
        public static IReadOnlyList<T> AsReadOnly<T>(this IEnumerable<T> src) =>
            src.ToList().AsReadOnly();
    }
}