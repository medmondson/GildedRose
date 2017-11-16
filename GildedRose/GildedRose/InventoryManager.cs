using System.Collections.Generic;

namespace GildedRose
{
    public class InventoryManager
    {
        private readonly IItemFactory itemFactory = new MemoryItemFactory();
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