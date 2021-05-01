using KataWardrobe.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KataWardrobe.Core.Domain.Models
{
    public class Wardrobe
    {
        public List<WardrobeElement> Elements { get; private set; }
        public int Size { get; private set; }
        public int Price { get; private set; }

        public Wardrobe(List<WardrobeElement> elements)
        {
            if (elements.IsNullOrEmpty())
                throw new ArgumentException("Wardrobe must be composed of at least one element");

            Elements = elements;
            Price = elements.Sum(e => e.Price);
            Size = elements.Sum(e => e.Size);
        }

    }
}