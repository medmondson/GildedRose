namespace GildedRose.Items
{
    public class Normal : IDegradeableItem
    {
        public int Sellin { get; private set; }
        public string Name { get; }
        public int Quality { get; private set; }

        public Normal(int sellIn, int quality)
        {
            Name = "Normal Item";
            Sellin = sellIn;
            Quality = quality;
        }

        public void Degrade()
        {
            if (Sellin < 0)
                Quality = Quality - 2;

            if (Sellin > 0)
                Quality = Quality - 1;

            if (Quality > 50)
                Quality = 50;

            if (Quality < 0)
                Quality = 0;

            Sellin = Sellin - 1;
        }
    }
}