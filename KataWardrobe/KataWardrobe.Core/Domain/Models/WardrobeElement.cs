using KataWardrobe.Core.Constants;

namespace KataWardrobe.Core.Domain.Models
{
    public abstract class WardrobeElement
    {
        public int Size { get; protected set; }
        public int Price { get; protected set; }

        public bool FitsWall => Size <= FurnitureConstants.WARDROBE_WALL_SIZE;
    }
}