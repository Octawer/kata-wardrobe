using System.Collections.Generic;
using System.Linq;

namespace KataWardrobe.Core.Domain
{
    public class WardrobeElement
    {
        public int Size { get; set; }

        public bool HasValidSize => Size > 0;

        public static List<WardrobeElement> ConvertFromSizes(int[] sizes)
        {
            return sizes.Select(s => new WardrobeElement { Size = s }).ToList();
        }
    }
}