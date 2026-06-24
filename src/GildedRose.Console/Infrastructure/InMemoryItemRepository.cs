using GildedRose.Domain.Models;
using GildedRose.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRose.Console.Infrastructure
{
    public class InMemoryItemRepository : IItemRepository
    {
        public IList<Item> GetInitialItmes()
        {
            return new List<Item>
            {
                new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                new ItemBuilder().WithName("Aged Brie").WithSellIn(2).WithQuality(0).Build(),
                new ItemBuilder().WithName("Elixir of the Mongoose").WithSellIn(5).WithQuality(7).Build(),
                new ItemBuilder().WithName("Sulfuras, Hand of Ragnaros").WithSellIn(0).WithQuality(80).Build(),
                new ItemBuilder().WithName("Backstage passes to a TAFKAL80ETC concert").WithSellIn(15).WithQuality(20).Build(),
                new ItemBuilder().WithName("Conjured Mana Cake").WithSellIn(3).WithQuality(6).Build()
            };
        }
    }
}
