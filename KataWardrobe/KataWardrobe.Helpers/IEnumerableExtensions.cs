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

        /// <summary>
        /// Generates all the subsets of a given set (aka Power Set)
        /// including the empty set and the original one
        /// Use a bitwise "mask" to know which original elements has to add to the power set
        /// e.g. for int array: {50, 75, 100}
        /// 0 -> "000" -> {50, 75, 100} -> {0,0,0} -> {}
        /// 1 -> "001" -> {50, 75, 100} -> {0,0,100} -> {100}
        /// 2 -> "010" -> {50, 75, 100} -> {0,75,0} -> {75}
        /// 3 -> "011" -> {50, 75, 100} -> {0,75,100} -> {75, 100}
        /// 4 -> "100" -> {50, 75, 100} -> {50,0,0} -> {50}
        /// 5 -> "101" -> {50, 75, 100} -> {50,0,100} -> {50, 100}
        /// 6 -> "110" -> {50, 75, 100} -> {50,75,0} -> {50, 75}
        /// 7 -> "111" -> {50, 75, 100} -> {50,75,100} -> {50, 75, 100}
        /// </summary>
        /// <typeparam name="T">source collection type</typeparam>
        /// <param name="source">source collection</param>
        /// <returns>All the posible subsets of the given set</returns>
        public static HashSet<IEnumerable<T>> PowerSet<T>(this IEnumerable<T> source)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            var powerSet = new HashSet<IEnumerable<T>>();

            int maskLenght = source.Count();
            var powerSetCount = Math.Pow(2, maskLenght);
            for (int powerSetIndex = 0; powerSetIndex < powerSetCount; powerSetIndex++)
            {
                var subset = new List<T>();
                var mask = Convert.ToString(powerSetIndex, 2).PadLeft(maskLenght, '0');
                for (int maskPosition = 0; maskPosition < mask.Length; maskPosition++)
                {
                    var shouldIncludeAtMaskPosition = mask[maskPosition] == '1';
                    if (!shouldIncludeAtMaskPosition)
                        continue;

                    var maskPositionElement = source.ElementAt(maskPosition);
                    subset.Add(maskPositionElement);
                }
                powerSet.Add(subset);
            }

            return powerSet;
        }

    }
}
