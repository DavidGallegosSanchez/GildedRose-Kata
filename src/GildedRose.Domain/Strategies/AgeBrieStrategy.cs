using System;
using System.Collections.Generic;
using System.Text;
using GildedRose.Domain.Models;

namespace GildedRose.Domain.Strategies
{
    public class AgeBrieStrategy : IItemUpdateStrategy
    {

        public bool AppliesTo(Item item) => item.Name == "Aged Brie";
        public Item Update(Item item)
        {
            int nextSeelIn = item.SellIn - 1;
            int nextQuality = item.Quality;

            if (nextQuality < 50) nextQuality++;
            if (nextSeelIn < 0 && nextQuality < 50) nextQuality++;
            
            return item.Mutate(nextSeelIn, nextQuality);
        }
    }
}
