using System;
using System.Collections.Generic;
using System.Text;
using GildedRose.Domain.Models;

namespace GildedRose.Domain.Strategies
{
    public class CommonItemStrategy : IItemUpdateStrategy
    {
        public bool AppliesTo(Item item) => 
            item.Name != "Aged Brie" &&
            item.Name != "Sulfuras, Hand of Ragnaros" 
            && item.Name != "Backstage passes to a TAFKAL80ETC concert";


        public Item Update(Item item)
        {
            int nextSeelIn = item.SellIn - 1;
            int nextQuality = item.Quality;

            if (nextQuality > 0) nextQuality--;
            if(nextSeelIn < 0 && nextQuality > 0) nextQuality--;

            return item.Mutate(nextSeelIn, nextQuality);
        }
    }
}
