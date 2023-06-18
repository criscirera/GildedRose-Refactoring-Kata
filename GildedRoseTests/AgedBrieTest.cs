using GildedRoseKata;
using NUnit.Framework;
using System.Collections.Generic;

namespace GildedRoseTests;

public class AgedBrieTests
{
    [Test]
    public void AgedBrie_QualityIncreasesByOne_SellInDateIsPositive()
    {
        int originalQuality = 0;
        var items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 1, Quality = 0 } };
        var gildedRose = new GildedRose(items);

        gildedRose.UpdateQuality();

        int newQuality = items[0].Quality;

        Assert.AreEqual(originalQuality + 1, newQuality);
    }

    [Test]
    public void AgedBrie_QualityIncreasesByTwo_SellInDateIsZeroOrNegative()
    {
        int originalQuality = 0;
        var items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 0, Quality = 0 } };
        var gildedRose = new GildedRose(items);

        gildedRose.UpdateQuality();

        int newQuality = items[0].Quality;

        Assert.AreEqual(originalQuality + 2, newQuality);
    }

    [Test]
    public void AgedBrie_QualityCannotBeMoreThanFifty()
    {
        int originalQuality = 49;
        var items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 0, Quality = originalQuality } };
        var gildedRose = new GildedRose(items);

        gildedRose.UpdateQuality();

        int newQuality = items[0].Quality;

        Assert.AreEqual(50, newQuality);

        gildedRose.UpdateQuality();
        newQuality = items[0].Quality;

        Assert.AreEqual(50, newQuality);
    }
}