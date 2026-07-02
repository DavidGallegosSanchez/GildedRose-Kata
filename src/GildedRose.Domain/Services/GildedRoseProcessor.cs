using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GildedRose.Domain.Models;
using GildedRose.Domain.Strategies;

namespace GildedRose.Domain.Services
{
    public class GildedRoseProcessor
    {
        private readonly List<IItemUpdateStrategy> _strategies;

        public GildedRoseProcessor()
        {
            _strategies = new List<IItemUpdateStrategy>
            {
                new AgeBrieStrategy(),
                new SulfurasStrategy(),
                new BackstagePassesStrategy(),
                new CommonItemStrategy()
            };
        }

        public IList<Item> ProcessItems(IList<Item> items)
        {
            return items.Select(item =>
            {
            var strategy = _strategies.First(s => s.AppliesTo(item));
             return strategy.Update(item);             
            }).ToList();            
        }
    }
}
