using System;
using System.Collections.Generic;
using System.Text;
using GildedRose.Domain.Models;

namespace GildedRose.Domain.Strategies
{
    public class SulfurasStrategy : IItemUpdateStrategy
    {
        public bool AppliesTo(Item item) => item.Name == "Sulfuras, Hand of Ragnaros";
        public Item Update(Item item) => item;
    {
    }
}
