using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace csharp
{
    [TestFixture]
    public class GildedRoseTest
    {

        [Test]
        public void DenoteSellInValue()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Stone", SellIn = 10, Quality = 0 } };
            for (int i = 0; i < 10; i++)
            {
                GildedRose.UpdateQuality(Items);
            }
            Assert.AreEqual(0, Items.FirstOrDefault().SellIn);
        }
        [Test]
        public void DenoteQualityValue()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Silver", SellIn = 100, Quality = 50 } };
            for (int i = 0; i < 25; i++)
            {
                GildedRose.UpdateQuality(Items);
            }
            Assert.AreEqual(25, Items.FirstOrDefault().Quality) ;
        }
        [Test]
        public void DenoteQualityTwiceAsFast()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Shoes", SellIn = 0, Quality = 20 } };
            for (int i = 0; i < 10; i++)
            {
                GildedRose.UpdateQuality(Items);
            }
            Assert.AreEqual(0, Items.FirstOrDefault().Quality);
        }
        [Test]
        public void DenoteQualityNeverBellowZero()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Stone", SellIn = 1, Quality = 0 } };
            for (int i = 0; i < 2; i++)
            {
                GildedRose.UpdateQuality(Items);
            }
            Assert.AreEqual(new Item { Name = "Stone", SellIn = -1, Quality = 0 }.ToString(), Items.FirstOrDefault().ToString());
        }
        [Test]
        public void DenoteSulfuras()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 } };
            for (int i = 0; i < 2; i++)
            {
                GildedRose.UpdateQuality(Items);
            }
            Assert.AreEqual(80, Items.FirstOrDefault().Quality);
            Assert.AreEqual(0, Items.FirstOrDefault().SellIn);
        }
        [Test]
        public void BackstagePassesRules()
        {
            IList<Item> Items = new List<Item> { 
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 20, Quality = 10 },
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 10 },
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 10 },
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 50 },
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 1, Quality = 49 }
            };

            GildedRose.UpdateQuality(Items);
            //normal Case
            Assert.AreEqual(11, Items[0].Quality);
            //SellIn <11
            Assert.AreEqual(12, Items[1].Quality);
            //SellIn <6
            Assert.AreEqual(13, Items[2].Quality);
            //SellIn <0
            Assert.AreEqual(0, Items[3].Quality);
            Assert.AreEqual(-1, Items[3].SellIn);
            //Quality Stuck at 50 and sell in 0
            Assert.AreEqual(50, Items[4].Quality);
            Assert.AreEqual(0, Items[4].SellIn);
        }
        [Test]
        public void AgedBrieRules()
        {
            IList<Item> Items = new List<Item> {
                new Item { Name = "Aged Brie", SellIn = 1, Quality = 0 },
                new Item { Name = "Aged Brie", SellIn = 0, Quality = 2 },
                new Item { Name = "Aged Brie", SellIn = -4, Quality = 24 }
            };

            GildedRose.UpdateQuality(Items);
            Assert.AreEqual(1, Items[0].Quality);
            Assert.AreEqual(4, Items[1].Quality);
            Assert.AreEqual(26, Items[2].Quality);
        }
        [Test]
        public void ConjuredObjectRule()
        {
            IList<Item> Items = new List<Item> {
                new Item { Name = "Conjured underwear", SellIn = 1, Quality = 50 }
            };

            GildedRose.UpdateQuality(Items);
            //Conjured item are losing twice their quality
            Assert.AreEqual(48, Items.FirstOrDefault().Quality);
        }
        [Test]
        public void ConjuredObjectRuleWithSellInDenodeBellowZero()
        {
            IList<Item> Items = new List<Item> {
                new Item { Name = "Conjured underwear", SellIn = 0, Quality = 50 }
            };

            GildedRose.UpdateQuality(Items);
            //Conjured item are losing twice their quality and moreover twice their quality from sellIn rule
            Assert.AreEqual(46, Items.FirstOrDefault().Quality);
        }
    }
}

