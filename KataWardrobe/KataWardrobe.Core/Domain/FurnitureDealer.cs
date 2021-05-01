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

        public List<IEnumerable<WardrobeElement>> ConfigureWardrobe(List<WardrobeElement> elements)
        {
            if (!IsAnyFittingWall(elements))
            {
                return new List<IEnumerable<WardrobeElement>>();
            }

            var fittingElements = elements.PowerSet().Where(subset => AreAllFittingWall(subset)).ToList();

            return fittingElements;
        }

        private static bool IsAnyFittingWall(List<WardrobeElement> elements)
        {
            if (elements.IsNullOrEmpty())
                throw new ArgumentNullException(nameof(WardrobeElement));

            bool atLeastOneFitting = elements.Any(elem => elem.FitsWall);

            return atLeastOneFitting;
        }

        private static bool AreAllFittingWall(IEnumerable<WardrobeElement> elements)
        {
            if (elements is null)
                throw new ArgumentNullException(nameof(WardrobeElement));

            // we exclude empty subsets
            if (!elements.Any())
                return false;

            bool allFitting = elements.Sum(elem => elem.Size) <= FurnitureConstants.WARDROBE_WALL_SIZE;

            return allFitting;
        }
    }
}