using System.Collections.Generic;

namespace GildedRoseKata;

public class GildedRose
{
    IList<Item> Items;

    public GildedRose(IList<Item> Items)
    {
        this.Items = Items;
    }

    public void UpdateQuality()
    {
        for (var i = 0; i < Items.Count; i++)
        {
            var item = Items[i];
            updateQualityOf(item);
        }
    }

    private const string BACK_STAGE = "Backstage passes to a TAFKAL80ETC concert";
    private const string AGED_BRIE = "Aged Brie";
    private const string SULFURAS = "Sulfuras, Hand of Ragnaros";
    private const int MAX_QUALITY = 50;
    private const int NO_QUALITY = 0;
    private const int DAYS_TO_INCREASE_TWO_UNITS_QUALITY = 10;
    const int DAYS_TO_INCREASE_THREE_UNITS_QUALITY = 5;

    private static void updateQualityOf(Item item)
    {
        if (item.Name != AGED_BRIE && item.Name != BACK_STAGE)
        {
            if (item.Quality > NO_QUALITY)
            {
                if (item.Name != SULFURAS)
                {
                    item.Quality -= 1;
                }
            }
        }
        else
        {
            if (item.Quality < MAX_QUALITY)
            {
                item.Quality += 1;

                if (item.Name == BACK_STAGE)
                {
                    if (item.SellIn <= DAYS_TO_INCREASE_TWO_UNITS_QUALITY)
                    {
                        if (item.Quality < MAX_QUALITY)
                        {
                            item.Quality += 1;
                        }
                    }

                    if (item.SellIn <= DAYS_TO_INCREASE_THREE_UNITS_QUALITY)
                    {
                        if (item.Quality < MAX_QUALITY)
                        {
                            item.Quality += 1;
                        }
                    }
                }
            }
        }

        if (item.Name != SULFURAS)
        {
            item.SellIn -= 1;
        }

        if (item.SellIn < NO_QUALITY)
        {
            if (item.Name != AGED_BRIE)
            {
                if (item.Name != BACK_STAGE)
                {
                    if (item.Quality > NO_QUALITY)
                    {
                        if (item.Name != SULFURAS)
                        {
                            item.Quality -= 1;
                        }
                    }
                }
                else
                {
                    item.Quality -= item.Quality;
                }
            }
            else
            {
                if (item.Quality < MAX_QUALITY)
                {
                    item.Quality += 1;
                }
            }
        }
    }
}