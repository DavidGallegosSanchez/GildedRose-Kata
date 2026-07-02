using System.Collections.Generic;
using System.Linq;
using GildedRose.Domain.Models;
using GildedRose.Domain.Repositories;

namespace GildedRose.Infrastructure
{
    public class InMemoryItemRepository : IItemRepository
    {
        private List<Item> _items => new List<Item>
            {
                new ItemBuilder().WithName("+5 Dexterity Vest").WithSellIn(10).WithQuality(20).Build(),
                new ItemBuilder().WithName("Aged Brie").WithSellIn(2).Build(),
                new ItemBuilder().WithName("Elixir of the Mongoose").WithSellIn(5).WithQuality(7).Build(),
                new ItemBuilder().WithName("Sulfuras, Hand of Ragnaros").WithQuality(80).Build(),
                new ItemBuilder().WithName("Backstage passes to a TAFKAL80ETC concert").WithSellIn(15).WithQuality(20).Build(),
                new ItemBuilder().WithName("Conjured Mana Cake").WithSellIn(3).WithQuality(6).Build()
            };

        public IList<Item> GetAllItmes()
        {
            return _items.ToList();
        }
    }
}
