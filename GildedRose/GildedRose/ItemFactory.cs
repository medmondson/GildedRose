using GildedRose.Items;

namespace GildedRose
{
    public class ItemFactory : IItemFactory
    {
        //Item factory stub. A real application would implement this for 
        public IDegradeableItem Create(string itemName, int sellin, int quality)
        {
            switch (itemName)
            {
                case "Normal Item":
                    return new Normal(sellin, quality);
                case "Sulfras":
                    return new Sulfras(sellin, quality);
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