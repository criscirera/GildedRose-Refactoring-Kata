using System.Collections.Generic;
using GildedRoseKata;
using NUnit.Framework;


namespace GildedRoseTests;

public class SulfurasTests
{
    int originalQuality = 80;
    int originalSellIn = 0;
    private GildedRose gildedRose;
    private List<Item> Items;

    [SetUp]
    public void SetUp()
    {
        Items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = originalSellIn, Quality = originalQuality } };
        gildedRose = new GildedRose(Items);
    }

    [Test]
    public void Sulfuras_NotDecreaseInQuality()
    {
        gildedRose.UpdateQuality();

        int newQuality = Items[0].Quality;

        Assert.AreEqual(originalQuality, newQuality);
    }

    [Test]
    public void Sulfuras_SellInShouldNotDecrease()
    {
        gildedRose.UpdateQuality();

        int newSellIn = Items[0].SellIn;

        Assert.AreEqual(originalSellIn, newSellIn);
    }
}