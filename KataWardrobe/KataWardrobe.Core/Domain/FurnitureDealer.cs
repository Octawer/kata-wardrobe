using KataWardrobe.Core.Constants;
using KataWardrobe.Core.Domain.Models;
using KataWardrobe.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KataWardrobe.Core.Domain
{
    public class FurnitureDealer
    {
        public FurnitureDealer() { }

        public List<Wardrobe> ConfigureWardrobes(List<WardrobeElement> elements)
        {
            if (!IsAnyFittingWall(elements))
            {
                return new List<Wardrobe>();
            }

            var wardrobes = elements.PowerSet()
                                    .Where(subset => AreAllFittingWall(subset))
                                    .Select(subset => WardrobeFactory.BuildWardrobe(subset.ToList()))
                                    .ToList();

            return wardrobes;
        }

        public Wardrobe OptimizeWardrobe(List<WardrobeElement> elements)
        {
            if (!IsAnyFittingWall(elements))
            {
                throw new ArgumentNullException("None of the elements fits the wall");
            }

            var optimalWardrobe = ConfigureWardrobes(elements).OrderByDescending(wardrobe => wardrobe.Size)
                                                              .ThenBy(wardrobe => wardrobe.Price)
                                                              .FirstOrDefault();
            return optimalWardrobe;
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