using System;
using System.Collections.Generic;
using System.Text;
using GildedRose.Domain.Models;

namespace GildedRose.Domain.Strategies
{
    public class BackstagePassesStrategy : IItemUpdateStrategy
    {
        public bool AppliesTo(Item item) => item.Name == "Backstage passes to a TAFKAL80ETC concert";
        public Item Update(Item item)
        {
            int nextSeelIn = item.SellIn - 1;
            int nextQuality = item.Quality;

            if (nextSeelIn < 0)
            {
                nextQuality = 0;
            } 
            else
            {
                if (nextQuality < 50) nextQuality++;
                if (nextSeelIn < 10 && nextQuality < 50) nextQuality++;
                if (nextSeelIn < 5 && nextQuality < 50) nextQuality++;
            }

            return item.Mutate(nextSeelIn, nextQuality);
        }    
    }
}
