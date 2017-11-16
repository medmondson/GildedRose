namespace GildedRose.Items
{
    public class Sulfuras : IDegradeableItem
    {
        public int Sellin { get; }
        public string Name { get; }
        public int Quality { get; }

        public Sulfuras(int sellin, int quality)
        {
            Name = "Sulfuras";
            Sellin = sellin;
            Quality = quality;
        }

        public void Degrade()
        {
            //Item does not degrade
        }
    }
}