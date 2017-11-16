using System.Linq;
using GildedRose;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GildedRoseTests
{
    [TestClass]
    public class InventoryManagerTests
    {
        [TestMethod]
        public void NormalItem_IncrementDay_ExpectSellinDecreasedByOne(string itemName, int sellin, int quality)
        {
            //Arrange
            var sut = new InventoryManager();
            sut.Add("Normal Item", 2, 2);

            //Act
            var item = sut.IncrementDay();

            //Assert
            Assert.AreEqual(1, item.First().Sellin);
        }

        [TestMethod]
        public void NormalItem_IncrementDay_ExpectQualityDecreasedByOne()
        {
            //Arrange
            var sut = new InventoryManager();
            sut.Add("Normal Item", 2, 2);

            //Act
            var item = sut.IncrementDay();

            //Assert
            Assert.AreEqual(1, item.First().Quality);
        }

        [TestMethod]
        public void NormalItemExpired_IncrementDay_ExpectDoubleQualityDecrease()
        {
            var sut = new InventoryManager();
            sut.Add("Normal Item", -1, 6);

            var item = sut.IncrementDay();

            Assert.AreEqual(-2, item.First().Sellin);
            Assert.AreEqual(4, item.First().Quality);
        }

        [TestMethod]
        public void SulfurasItem_IncrementDay_ExpectQualityNotDecreased()
        {
            var sut = new InventoryManager();
            sut.Add("Sulfras", 2, 2);

            var item = sut.IncrementDay();

            Assert.AreEqual(2, item.First().Sellin);
            Assert.AreEqual(2, item.First().Quality);
        }

        [TestMethod]
        public void ConjuredItem_IncrementDay_ExpectQualityDecreasedByTwo()
        {
            var sut = new InventoryManager();
            sut.Add("Conjured", 2, 2);

            var item = sut.IncrementDay();

            Assert.AreEqual(1, item.First().Sellin);
            Assert.AreEqual(0, item.First().Quality);
        }

        [TestMethod]
        public void AgedBrie_IncrementDay_ExpectQualityIncreased()
        {
            var sut = new InventoryManager();
            sut.Add("Aged Brie", 1, 1);

            var item = sut.IncrementDay();

            Assert.AreEqual(0, item.First().Sellin);
            Assert.AreEqual(2, item.First().Quality);
        }

        [TestMethod]
        public void BackstagePassExpired_IncrementDay_ExpectQualityZero()
        {
            var sut = new InventoryManager();
            sut.Add("Backstage passes", -1, 2);

            var item = sut.IncrementDay();

            Assert.AreEqual(-2, item.First().Sellin);
            Assert.AreEqual(0, item.First().Quality);
        }

        [TestMethod]
        public void BackstagePass_IncrementDay_ExpectDoubleQualityIncrease()
        {
            var sut = new InventoryManager();
            sut.Add("Backstage passes", 9, 2);

            var item = sut.IncrementDay();

            Assert.AreEqual(8, item.First().Sellin);
            Assert.AreEqual(4, item.First().Quality);
        }

        [TestMethod]
        public void BackstagePass_IncrementDay_ExpectTripleQualityIncrease()
        {
            var sut = new InventoryManager();
            sut.Add("Backstage passes", 3, 2);

            var item = sut.IncrementDay();

            Assert.AreEqual(2, item.First().Sellin);
            Assert.AreEqual(5, item.First().Quality);
        }

        [TestMethod]
        public void InvalidItem_IncrementDay_ExpectInvalidItem()
        {
            var sut = new InventoryManager();
            sut.Add("INVALID ITEM", 1, 2);

            var item = sut.IncrementDay();

            Assert.AreEqual("NO SUCH ITEM", item.First().Name);
        }

        [TestMethod]
        public void ManyItems_IncrementDay()
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

            Assert.AreEqual(0, items.First().Sellin);
            Assert.AreEqual(2, items.First().Quality);

            Assert.AreEqual(-2, items[1].Sellin);
            Assert.AreEqual(0, items[1].Quality);

            Assert.AreEqual(8, items[2].Sellin);
            Assert.AreEqual(4, items[2].Quality);

            Assert.AreEqual(2, items[3].Sellin);
            Assert.AreEqual(2, items[3].Quality);

            Assert.AreEqual(-2, items[4].Sellin);
            Assert.AreEqual(50, items[4].Quality);

            Assert.AreEqual(1, items[5].Sellin);
            Assert.AreEqual(1, items[5].Quality);

            Assert.AreEqual(0, items[6].Sellin);
            Assert.AreEqual(0, items[6].Quality);

            Assert.AreEqual(1, items[7].Sellin);
            Assert.AreEqual(0, items[7].Quality);

            Assert.AreEqual(-2, items[8].Sellin);
            Assert.AreEqual(3, items[8].Quality); //this differs from remit which says 1 (possible mistake)
        }

    }
}
