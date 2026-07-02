
namespace GildedRose.Domain.Models
{
    public class Item
    {
        public string Name { get; }
        public int SellIn { get; }
        public int Quality { get; }

        // internal constructor; only Builder can instanciate (or elements in the same domain)
        internal Item(string name, int sellIn, int quality)
        {
            Name = name;
            SellIn = sellIn;
            Quality = quality;
        }

        // Method to clone the item with new SellIn and Quality values
        public Item Mutate(int newSellIn, int newQuality)
        {
            return new Item(this.Name, newSellIn, newQuality);
        }
    }
}
