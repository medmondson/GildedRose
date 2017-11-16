namespace GildedRose.Items
{
    public class Normal : IDegradeableItem
    {
        public int Sellin { get; private set; }
        public string Name { get; }
        public int Quality { get; private set; }

        private readonly string name;

        public Normal(int sellIn, int quality)
        {
            name = "Normal Item";
            this.Sellin = sellIn;
            this.Quality = quality;
        }

        public void Degrade()
        {
            if (Sellin < 0)
                Quality = Quality - 2;

            if (Sellin > 0)
                Quality = Quality - 1;

            if (Quality > 50)
                Quality = 50;

            Sellin = Sellin - 1;
        }
    }
}