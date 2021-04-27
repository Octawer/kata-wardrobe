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

        public bool IsWardrobeFittingWall(List<WardrobeElement> elements)
        {
            if (elements.IsNullOrEmpty())
                throw new ArgumentNullException(nameof(WardrobeElement));

            bool atLeastOneFits = elements.Any(elem => elem.FitsWall);

            return atLeastOneFits;
        }

        public List<List<WardrobeElement>> ConfigureWardrobe(List<WardrobeElement> elements)
        {
            var fittingElements = new List<List<WardrobeElement>>();
            if (!IsWardrobeFittingWall(elements))
            {
                return fittingElements;
            }

            fittingElements.Add(new List<WardrobeElement> { elements.First(e => e.FitsWall) });
            return fittingElements;
        }
    }
}