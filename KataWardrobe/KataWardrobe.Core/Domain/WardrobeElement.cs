using KataWardrobe.Core.Constants;
using KataWardrobe.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KataWardrobe.Core.Domain
{
    public class WardrobeElement
    {
        public int Size { get; private set; }
        public int Price { get; private set; }

        public bool FitsWall => Size <= FurnitureConstants.WARDROBE_WALL_SIZE;

        private static readonly Dictionary<WardrobeElementSize, int> _prices = new Dictionary<WardrobeElementSize, int>
        {
            { WardrobeElementSize.S, 59 },
            { WardrobeElementSize.M, 62 },
            { WardrobeElementSize.L, 90 },
            { WardrobeElementSize.XL, 111 },
        };

        public WardrobeElement(WardrobeElementSize size)
        {
            if (!Enum.IsDefined(typeof(WardrobeElementSize), size))
                throw new ArgumentException($"Error: Size {size} - Wardrobe element can only have fixed sizes");

            Size = (int)size;
            Price = GetPrice(size);
        }

        public static List<WardrobeElement> ConvertFromSizes(int[] sizes)
        {
            return sizes.Where(size => Enum.IsDefined(typeof(WardrobeElementSize), size))
                        .Select(size => new WardrobeElement((WardrobeElementSize)size)).ToList();
        }

        private static int GetPrice(WardrobeElementSize size)
        {
            if (!_prices.TryGetValue(size, out int price))
                return default;

            return price;
        }
    }
}