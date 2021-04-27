using KataWardrobe.Core.Constants;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KataWardrobe.Core.Domain
{
    public class WardrobeElement
    {
        public int Size { get; set; }
        public bool HasValidSize => Size > 0;
        public bool FitsWall => Size <= FurnitureConstants.WARDROBE_WALL_SIZE;

        public WardrobeElement(int size)
        {
            Size = size;

            if (!HasValidSize)
                throw new ArgumentException($"Error: Size {size} - Wardrobe element can only have positive sizes");
        }

        public static List<WardrobeElement> ConvertFromSizes(int[] sizes)
        {
            return sizes.Select(size => new WardrobeElement(size)).ToList();
        }
    }
}