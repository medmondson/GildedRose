using System.Linq;
using GildedRose;
using NUnit.Framework;

namespace GildedRoseTests
{
    [TestFixture]
    public class InventoryManagerTests
    {
        [TestCase("Normal Item", 2, 2, 1)]
        [TestCase("Normal Item", -1, 6, 4)] //Expired so double quality decrease
        [TestCase("Normal Item", -1, 0, 0)] //Cannot have quality lower than 0
        [TestCase("Sulfuras", 2, 2, 2)] //Sulfras never decrease in quality
        [TestCase("Conjured", 2, 2, 0)] //Conjured quality degrades twice as fast
        [TestCase("Conjured", 2, 0, 0)] //Cannot have quality lower than 0
        [TestCase("Aged Brie", 1, 1, 2)] //Gets better with time
        [TestCase("Aged Brie", 1, 50, 50)] //Cannot have quality higher than 50
        [TestCase("Backstage passes", -1, 5, 0)] //Expired pass so quality zero
        [TestCase("Backstage passes", 9, 2, 4)] //Double quality increase when between 5 and 10 days to sell (+2)
        [TestCase("Backstage passes", 3, 2, 5)] //Triple quality increase when between 0 and 3 days to sell (+3)
        [TestCase("Backstage passes", 3, 50, 50)] //Cannot have quality higher than 50
        [TestCase("INVALID ITEM", 2, 2, 0)] //Invalid item doesn't track quality
        public void IncrementDay_ExpectQualityModification(string itemName, int sellin, int quality, int expectedQuality)
        {
            //Arrange
            var sut = new InventoryManager();
            sut.Add(itemName, sellin, quality);

            //Act
            var item = sut.IncrementDay();

            //Assert
            Assert.AreEqual(expectedQuality, item.First().Quality);
        }

        [TestCase("Normal Item", 2, 1)] // -1
        [TestCase("Normal Item", -1, -2)] // -1
        [TestCase("Sulfuras", 2, 2)] //Never have to be sold so sellin unchanged
        [TestCase("Conjured", 2, 1)] // -1
        [TestCase("Aged Brie", 2, 1)] // -1
        [TestCase("Backstage passes", 2, 1)] // -1
        [TestCase("INVALID ITEM", 2, 0)] //Invalid item doesn't track days to sell
        public void IncrementDay_ExpectSellinDecreasedByOne(string itemName, int sellin, int expectedSellin)
        {
            //Arrange
            var sut = new InventoryManager();
            sut.Add(itemName, sellin, 1);

            //Act
            var item = sut.IncrementDay();

            //Assert
            Assert.AreEqual(expectedSellin, item.First().Sellin);
        }

        //All items return their name as the description except for invalid item
        [TestCase("Normal Item", "Normal Item")]
        [TestCase("Aged Brie", "Aged Brie")]
        [TestCase("Sulfuras", "Sulfuras")]
        [TestCase("Backstage passes", "Backstage passes")]
        [TestCase("Conjured", "Conjured")]
        [TestCase("INVALID ITEM", "NO SUCH ITEM")]
        public void InvalidItem_IncrementDay_ExpectInvalidItem(string itemName, string expectedItemDescription)
        {
            var sut = new InventoryManager();
            sut.Add(itemName, 1, 2);

            var item = sut.IncrementDay();

            Assert.AreEqual(expectedItemDescription, item.First().Name);
        }

        //Proof of functionality from remit
        [Test]
        public void TestFromRemit()
        {
            var sut = new InventoryManager();
            sut.Add("Aged Brie", 1, 1); //0
            sut.Add("Backstage passes", -1, 2); //1
            sut.Add("Backstage passes", 9, 2); //2
            sut.Add("Sulfras", 2, 2); //3
            sut.Add("Normal Item", -1, 55); //4
            sut.Add("Normal Item", 2, 2); //5
            sut.Add("INVALID ITEM", 2, 2); //6
            sut.Add("Conjured", 2, 2); //7
            sut.Add("Conjured", -1, 5); //8

            var items = sut.IncrementDay();

            Assert.AreEqual(0, items[0].Sellin);
            Assert.AreEqual(2, items[0].Quality);

            Assert.AreEqual(-2, items[1].Sellin);
            Assert.AreEqual(0, items[1].Quality);

            Assert.AreEqual(8, items[2].Sellin);
            Assert.AreEqual(4, items[2].Quality);

            Assert.AreEqual(0, items[3].Sellin);
            Assert.AreEqual(0, items[3].Quality);

            Assert.AreEqual(-2, items[4].Sellin);
            Assert.AreEqual(50, items[4].Quality);

            Assert.AreEqual(1, items[5].Sellin);
            Assert.AreEqual(1, items[5].Quality);

            Assert.AreEqual(0, items[6].Sellin);
            Assert.AreEqual(0, items[6].Quality);

            Assert.AreEqual(1, items[7].Sellin);
            Assert.AreEqual(0, items[7].Quality);

            Assert.AreEqual(-2, items[8].Sellin);
            Assert.AreEqual(1, items[8].Quality);
        }

    }
}
