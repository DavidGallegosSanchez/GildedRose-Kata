using GildedRose.Domain.Models;
using System.Collections.Generic;

namespace GildedRose.Domain.Repositories
{
    public interface IItemRepository
    {
        IList<Item> GetAllItmes();
    }
}
