using KataWardrobe.Core.Constants;
using KataWardrobe.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KataWardrobe.Core.Domain
{
    public class FurnitureDealer
    {
        public FurnitureDealer() { }

        public HashSet<List<WardrobeElement>> ConfigureWardrobe(List<WardrobeElement> elements)
        {
            var fittingElements = new HashSet<List<WardrobeElement>>();
            if (!IsAnyFittingWall(elements))
            {
                return fittingElements;
            }

            if (AreAllFittingWall(elements))
            {
                fittingElements.Add(elements);
                var individualCombinations = elements.Select(elem => new List<WardrobeElement> { elem });
                foreach (var comb in individualCombinations)
                {
                    fittingElements.Add(comb);
                }
                return fittingElements;
            }

            fittingElements.Add(new List<WardrobeElement> { elements.First(e => e.FitsWall) });
            return fittingElements;
        }

        private static bool IsAnyFittingWall(List<WardrobeElement> elements)
        {
            if (elements.IsNullOrEmpty())
                throw new ArgumentNullException(nameof(WardrobeElement));

            bool atLeastOneFitting = elements.Any(elem => elem.FitsWall);

            return atLeastOneFitting;
        }

        private static bool AreAllFittingWall(List<WardrobeElement> elements)
        {
            if (elements.IsNullOrEmpty())
                throw new ArgumentNullException(nameof(WardrobeElement));

            bool allFitting = elements.Sum(elem => elem.Size) <= FurnitureConstants.WARDROBE_WALL_SIZE;

            return allFitting;
        }

        // {50, 75, 100}
        // 0 -> "000" -> {50, 75, 100} -> {0,0,0} -> {}
        // 1 -> "001" -> {50, 75, 100} -> {0,0,100} -> {100}
        // 2 -> "010" -> {50, 75, 100} -> {0,75,0} -> {75}
        // 3 -> "011" -> {50, 75, 100} -> {0,75,100} -> {75, 100}
        // 4 -> "100" -> {50, 75, 100} -> {50,0,0} -> {50}
        // 5 -> "101" -> {50, 75, 100} -> {50,0,100} -> {50, 100}
        // 6 -> "110" -> {50, 75, 100} -> {50,75,0} -> {50, 75}
        // 7 -> "111" -> {50, 75, 100} -> {50,75,100} -> {50, 75, 100}
        private static HashSet<List<int>> GetAllCombinations(int[] sizes) 
        {
            return sizes.PowerSet();
        }
    }
}