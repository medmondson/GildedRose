﻿namespace GildedRose.Items
{
    public class AgedBrie : IDegradeableItem
    {
        public int Quality { get; private set; }
        public int Sellin { get; private set; }
        public string Name { get; }

        public AgedBrie(int sellin, int quality)
        {
            Name = "Aged Brie";
            Sellin = sellin;
            Quality = quality;
        }

        public void Degrade()
        {
            Sellin = Sellin - 1;
            Quality = Quality + 1; //gets better with age

            if (Quality > 50)
                Quality = 50;
        }
    }
}