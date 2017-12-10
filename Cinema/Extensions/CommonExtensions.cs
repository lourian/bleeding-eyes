using System.Collections.Generic;

namespace Cinema.Extensions
{
    public static class CommonExtensions
    {
        public static bool NullOrEmpty<T>(this IEnumerable<T> list)
        {
            return list == null || !list.GetEnumerator().MoveNext();
        }
    }
}
