using GildedRose.Domain.Models;
using GildedRose.Domain.Repositories;
using GildedRose.Domain.Services;
using GildedRose.Infrastructure;
using System.Collections.Generic;
using System.Linq;

namespace GildedRose.Console
{
    class Program
    {
        private readonly IItemRepository _itemRepository;
        private readonly GildedRoseProcessor _processor;

        public Program(IItemRepository itemRepository, GildedRoseProcessor processor)
        {
            _itemRepository = itemRepository;
            _processor = processor;
        }
        static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");

            IItemRepository repository = new InMemoryItemRepository();
            GildedRoseProcessor processor = new GildedRoseProcessor();

            var app = new Program(repository, processor);

            IList<Item> Items = app._itemRepository.GetAllItmes();

            IList<Item> updatedItems = app._processor.ProcessItems(Items);

            System.Console.ReadKey();
        }
    }
}

    
