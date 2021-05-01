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

        private readonly uint[] _availableSizes = new uint[] { 50, 75, 100, 120 };

        public WardrobeElement(uint size)
        {
            if (size == 0)
                throw new ArgumentException($"Error: Size {size} - Wardrobe element can only have positive, non-zero sizes");

            if (!_availableSizes.Contains(size))
                throw new ArgumentException($"Error: allowed sizes are only {string.Join(',', _availableSizes)}");

            Size = size;
        }

        public static List<WardrobeElement> ConvertFromSizes(uint[] sizes)
        {
            return sizes.Select(size => new WardrobeElement(size)).ToList();
        }
    }
}