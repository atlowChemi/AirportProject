using System.Collections.Generic;

namespace Simulator.HelperClasses
{
    public static class LinqHelpers
    {
        public static TSource GetItemAtIndex<TSource>(this IEnumerable<TSource> source, int index)
        {
            int i = 0;
            foreach (TSource item in source)
            {
                if (i++ == index)
                {
                    return item;
                }
            }
            return default;
        }
    }
}
