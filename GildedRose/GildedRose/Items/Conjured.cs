namespace GildedRose.Items
{
    public class Conjured : IDegradeableItem
    {
        public int Quality { get; private set; }
        public int Sellin { get; private set; }
        public string Name { get; }

        public Conjured(int sellin, int quality)
        {
            Sellin = sellin;
            Quality = quality;
        }

        public void Degrade()
        {
            Sellin = Sellin - 1;
            Quality = Quality - 2; //degrades twice as fast
        }
    }
}