using GildedRose.Items;

namespace GildedRose
{
    public class MemoryItemFactory : IItemFactory
    {
        //In memory stub, other implentations of IItemFactory could be made for other data stores
        public IDegradeableItem Create(string itemName, int sellin, int quality)
        {
            switch (itemName)
            {
                case "Normal Item":
                    return new Normal(sellin, quality);
                case "Sulfuras":
                    return new Sulfuras(sellin, quality);
                case "Conjured":
                    return new Conjured(sellin, quality);
                case "Aged Brie":
                    return new AgedBrie(sellin, quality);
                case "Backstage passes":
                    return new BackstagePass(sellin, quality);

                default:
                    return new Invalid();

            }

            
        }

       
    }
}