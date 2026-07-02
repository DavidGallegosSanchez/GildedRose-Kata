using GildedRose.Domain.Models;

namespace GildedRose.Domain.Strategies
{
    public interface IItemUpdateStrategy
    {
        bool AppliesTo(Item item);
        Item Update(Item item);
    }
}
