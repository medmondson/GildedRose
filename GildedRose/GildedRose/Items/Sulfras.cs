namespace GildedRose.Items
{
    public class Sulfras : IDegradeableItem
    {
        public int Sellin { get; }
        public string Name { get; }
        public int Quality { get; }

        private readonly string name;

        public Sulfras(int sellin, int quality)
        {
            name = "Sulfras";
            Sellin = sellin;
            Quality = quality;
        }

        public void Degrade()
        {
            //Item does not degrade
        }
    }
}