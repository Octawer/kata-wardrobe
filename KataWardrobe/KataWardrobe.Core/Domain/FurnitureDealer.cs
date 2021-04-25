using KataWardrobe.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KataWardrobe.Core.Domain
{
    public class FurnitureDealer
    {
        public FurnitureDealer()
        {
        }

        public bool IsWardrobeFittingWall(List<WardrobeElement> elements)
        {
            if (elements.IsNullOrEmpty())
                throw new ArgumentNullException(nameof(WardrobeElement));

            if (!elements.All(elem => elem.HasValidSize))
                throw new ArgumentException("One or more wardrobe elements have invalid size defined");

            int totalElementsSize = elements.Sum(elem => elem.Size);

            return totalElementsSize < 250;
        }

        public List<List<WardrobeElement>> ConfigureWardrobe(List<WardrobeElement> elements)
        {
            var fittingElements = new List<List<WardrobeElement>>();
            if (IsWardrobeFittingWall(elements))
            {
                fittingElements.Add(elements);
            }

            return fittingElements;
        }
    }
}