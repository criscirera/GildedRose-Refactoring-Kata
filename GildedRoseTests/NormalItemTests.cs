using System.Collections.Generic;
using GildedRoseKata;
using NUnit.Framework;

namespace GildedRoseTests;

public class NormalItemTests
{
    [Test()]
    public void NormalItem_DegradeQualityByOne_ItemHasPositiveSellIn()
    {
        int originalQuality = 20;
        var Items = new List<Item> { new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = originalQuality } };
        var gildedRose = new GildedRose(Items);
        gildedRose.UpdateQuality();

        Item alteredItem = Items[0];

        Assert.AreEqual(originalQuality - 1, alteredItem.Quality);
    }

    [Test()]
    public void NormalItem_DegradeSellInByOne_ItemHasPositiveSellIn()
    {
        int originalSellIn = 10;
        var Items = new List<Item> { new Item { Name = "+5 Dexterity Vest", SellIn = originalSellIn, Quality = 20 } };
        var gildedRose = new GildedRose(Items);

        gildedRose.UpdateQuality();

        Item alteredItem = Items[0];

        Assert.AreEqual(originalSellIn - 1, alteredItem.SellIn);
    }

    [Test()]
    public void NormalItem_QualityDegradesTwiceAsFast_SellInDateNegative()
    {
        int originalQuality = 20;
        var Items = new List<Item> { new Item { Name = "+5 Dexterity Vest", SellIn = 0, Quality = originalQuality } };
        var gildedRose = new GildedRose(Items);
        gildedRose.UpdateQuality();

        Item alteredItem = Items[0];

        Assert.AreEqual(originalQuality - 2, alteredItem.Quality);
    }

    [Test]
    public void NormalItem_QualityIsNeverNegative()
    {
        int originalQuality = 0;
        var Items = new List<Item> { new Item { Name = "+5 Dexterity Vest", SellIn = 0, Quality = originalQuality } };
        var gildedRose = new GildedRose(Items);
        gildedRose.UpdateQuality();

        Item alteredItem = Items[0];

        Assert.AreEqual(originalQuality, alteredItem.Quality);
    }
}