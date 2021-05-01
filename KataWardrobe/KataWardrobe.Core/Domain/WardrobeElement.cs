using KataWardrobe.Core.Constants;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KataWardrobe.Core.Domain
{
    public class WardrobeElement
    {
        public uint Size { get; set; }
        public bool FitsWall => Size <= FurnitureConstants.WARDROBE_WALL_SIZE;

        public WardrobeElement(uint size)
        {
            if (size == 0)
                throw new ArgumentException($"Error: Size {size} - Wardrobe element can only have positive, non-zero sizes");

            if (size != 50 && size != 75 && size != 100 && size != 120)
                throw new ArgumentException($"Error: allowed sizes are only {50}, {75}, {100}, {120}");

            Size = size;
        }

        public static List<WardrobeElement> ConvertFromSizes(uint[] sizes)
        {
            return sizes.Select(size => new WardrobeElement(size)).ToList();
        }
    }
}