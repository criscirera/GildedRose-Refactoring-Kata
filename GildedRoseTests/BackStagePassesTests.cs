using System.Collections.Generic;
using GildedRoseKata;
using NUnit.Framework;

namespace GildedRoseTests;

public class BackStagePassesTests
{
    int originalQuality = 80;
    int originalSellIn = 0;

    public Item getPass(int sellIn, int quality)
    {
        return new Item
        {
            Name = "Backstage passes to a TAFKAL80ETC concert",
            SellIn = sellIn,
            Quality = quality
        };
    }

    [Test]
    public void BackstagePass_QualityIncreaseByOne_SellInDateGreaterThanTen()
    {
        int originalQuality = 20;
        int originalSellIn = 15;

        var items = new List<Item> { getPass(originalSellIn, originalQuality) };
        var gildedRose = new GildedRose(items);

        gildedRose.UpdateQuality();

        int newQuality = items[0].Quality;

        Assert.AreEqual(originalQuality + 1, newQuality);
    }

    [Test]
    public void BackstagePass_QualityIncreaseByTwo_SellInDateBetweenTenAndSix()
    {
        int originalQuality = 20;
        int originalSellIn = 10;
        var Items = new List<Item> { getPass(originalSellIn, originalQuality) };
        var gildedRose = new GildedRose(Items);

        gildedRose.UpdateQuality();

        int newQuality = Items[0].Quality;

        Assert.AreEqual(originalQuality + 2, newQuality);
    }

    [Test]
    public void BackstagePass_QualityIncreaseByTwo_SellInDateBetweenFiveAndZero()
    {
        int originalQuality = 20;
        int originalSellIn = 5;
        var Items = new List<Item> { getPass(originalSellIn, originalQuality) };
        var gildedRose = new GildedRose(Items);

        gildedRose.UpdateQuality();

        int newQuality = Items[0].Quality;

        Assert.AreEqual(originalQuality + 3, newQuality);
    }

    [Test]
    public void BackstagePass_QualityShouldBeZero_WhenSellInDateNegative()
    {
        int originalQuality = 20;
        int originalSellIn = 0;
        var Items = new List<Item> { getPass(originalSellIn, originalQuality) };
        var gildedRose = new GildedRose(Items);

        gildedRose.UpdateQuality();

        int newQuality = Items[0].Quality;

        Assert.AreEqual(0, newQuality);
    }

    [Test]
    public void BackstagePass_QualityCannotBeMoreThanFifty()
    {
        int originalQuality = 49;
        int originalSellIn = 10;
        var Items = new List<Item> { getPass(originalSellIn, originalQuality) };
        var gildedRose = new GildedRose(Items);

        gildedRose.UpdateQuality();

        int newQuality = Items[0].Quality;

        Assert.AreEqual(50, newQuality);

        gildedRose.UpdateQuality();
        newQuality = Items[0].Quality;

        Assert.AreEqual(50, newQuality);
    }
}