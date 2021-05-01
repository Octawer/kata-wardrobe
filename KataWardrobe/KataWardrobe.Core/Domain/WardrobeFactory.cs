using KataWardrobe.Core.Domain.Enums;
using KataWardrobe.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KataWardrobe.Core.Domain
{
    public class WardrobeFactory 
    {
        private static readonly Dictionary<WardrobeElementSize, WardrobeElement> _prices = new Dictionary<WardrobeElementSize, WardrobeElement>
        {
            { WardrobeElementSize.S, new ModuleS() },
            { WardrobeElementSize.M, new ModuleM() },
            { WardrobeElementSize.L, new ModuleL() },
            { WardrobeElementSize.XL, new ModuleXL() },
        };

        public static WardrobeElement Build(WardrobeElementSize size) 
        {
            if (!Enum.IsDefined(typeof(WardrobeElementSize), size))
                throw new ArgumentException($"Error: Size {size} - Wardrobe element can only have fixed sizes");

            return _prices.TryGetValue(size, out var element) ? element : throw new ArgumentException($"Error: module not found for size {size}");
        }

        public static List<WardrobeElement> Build(WardrobeElementSize[] sizes) 
        {
            return sizes.Select(size => Build(size)).ToList();
        }
    }
}