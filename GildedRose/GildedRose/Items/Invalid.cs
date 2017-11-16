namespace GildedRose.Items
{
    public class Invalid : IDegradeableItem
    {
        public Invalid()
        {
            Name = "NO SUCH ITEM";
        }

        public int Quality { get; }
        public int Sellin { get; }
        public string Name { get; }
        public void Degrade()
        {
            //Invalid item cannot degrade
        }
    }
}