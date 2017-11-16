namespace GildedRose.Items
{
    public class Conjured : IDegradeableItem
    {
        public int Quality { get; private set; }
        public int Sellin { get; private set; }
        public string Name { get; }

        public Conjured(int sellin, int quality)
        {
            Name = "Conjured";
            Sellin = sellin;
            Quality = quality;
        }

        public void Degrade()
        {
            var degradesMultiplier = 2;

            if (Sellin < 0)
                degradesMultiplier = degradesMultiplier * 2;

            Sellin = Sellin - 1;
            Quality = Quality - degradesMultiplier; //degrades twice as fast

            if (Quality < 0)
                Quality = 0;
        }
    }
}