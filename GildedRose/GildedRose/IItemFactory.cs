namespace GildedRose
{
    public interface IItemFactory
    {
        IDegradeableItem Create(string itemName, int sellin, int quality);
    }
}