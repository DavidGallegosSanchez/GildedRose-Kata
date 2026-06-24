using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRose.Domain.Models
{
    public class ItemBuilder
    {
        private string? _name;
        private int _sellIn = 0;
        private int _quality = 0;
    
        public ItemBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public ItemBuilder WithSellIn(int sellIn)
        {
            _sellIn = sellIn;
            return this;
        }

        public ItemBuilder WithQuality(int quality)
        {
            _quality = quality; 
            return this;
        }

        public Item Build()
        {
            if (string.IsNullOrEmpty(_name))
                throw new InvalidOperationException("The Item should have name.");

            return new Item
            {
                Name = _name,
                SellIn = _sellIn,
                Quality = _quality
            };
        }
    }
}
