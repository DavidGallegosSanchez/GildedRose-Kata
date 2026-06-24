using GildedRose.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRose.Domain.Repositories
{
    public interface IItemRepository
    {
        IList<Item> GetInitialItmes();
    }
}
