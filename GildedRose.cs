using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace GildedRoseKata;

public class GildedRose
{
    IList<Item> Items;
    int QualityDecrease;

    public GildedRose(IList<Item> Items)
    {
        this.Items = Items;
    }

    public void UpdateQuality()
    {
        for (var i = 0; i < Items.Count; i++)
        {
            if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
            {
                Items[i].SellIn = Items[i].SellIn - 1;
            }

            switch (Items[i].Name)
            {
                case "Aged Brie":
                    QualityDecrease = 1;
                    break;
                case "Sulfuras, Hand of Ragnaros":
                    QualityDecrease = 0;
                    break;
                case "Backstage passes to a TAFKAL80ETC concert":
                    ConcertCheck(Items[i].SellIn);
                    break;
                default:
                    if (Items[i].Name.Contains("Conjured"))
                    {
                        QualityDecrease = -2;
                    }
                    else
                    {
                        QualityDecrease = -1;
                    }
                    break;
            }
            if (Items[i].SellIn < 0)
            {
                Items[i].Quality = Items[i].Quality + QualityDecrease * 2;
            }
            Items[i].Quality = Items[i].Quality + QualityDecrease;
        }
    }
    public void ConcertCheck(int SellIn)
    {
        if (SellIn < 12)
        {
            QualityDecrease = 1;
        }
        if (SellIn < 11)
        {
            QualityDecrease = 2;
        }
        if (SellIn < 6)
        {
            QualityDecrease = 3;
        }
        if (SellIn == 0)
        {
            QualityDecrease = 0;
        }
    }
}