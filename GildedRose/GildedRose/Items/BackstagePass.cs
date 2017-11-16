namespace GildedRose.Items
{
    public class BackstagePass : IDegradeableItem
    {
        public int Quality { get; private set; }
        public int Sellin { get; private set; }
        public string Name { get; }

        public BackstagePass(int sellin, int quality)
        {
            Sellin = sellin;
            Quality = quality;
        }

        public void Degrade()
        {
            Sellin = Sellin - 1;

            if (Sellin > 5 & Sellin <= 10)
                Quality = Quality + 2;

            if (Sellin <= 5)
                Quality = Quality + 3;

            if (Sellin < 0)
                Quality = 0;
        }
    }
}