namespace GildedRose
{
    public interface IDegradeableItem
    {
        int Quality { get; }
        int Sellin { get; }

        string Name { get; }

        void Degrade();
    }
}