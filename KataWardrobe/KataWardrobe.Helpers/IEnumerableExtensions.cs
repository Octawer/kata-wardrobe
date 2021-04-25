using System;
using System.Collections.Generic;
using System.Linq;

namespace KataWardrobe.Helpers
{
    public static class IEnumerableExtensions
    {
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> collection) 
        {
            return collection == null || !collection.Any();
        }

    }
}
