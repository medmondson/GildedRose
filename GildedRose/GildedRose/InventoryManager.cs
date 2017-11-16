using System.Collections.Generic;
using GildedRose.Items;

namespace GildedRose
{
    public class InventoryManager
    {
        private readonly ItemFactory itemFactory = new ItemFactory();
        private readonly List<IDegradeableItem> items = new List<IDegradeableItem>();

        public void Add(string itemName, int sellin, int quality)
        {
            var item = itemFactory.Create(itemName, sellin, quality);

            items.Add(item);
        }

        public List<IDegradeableItem> IncrementDay()
        {
            foreach (var item in items)
            {
                item.Degrade();
            }

            return items;
        }
    }
}