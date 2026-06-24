using GildedRose.Console.Infrastructure;
using GildedRose.Domain.Models;
using GildedRose.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace GildedRose.Console
{
    class Program
    {
        private readonly IItemRepository _itemRepository;

        public Program(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }
        static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");

            IItemRepository repository = new InMemoryItemRepository();
            var app = new Program(repository);

            IList<Item> Items = app._itemRepository.GetInitialItmes();

            app.UpdateQuality(Items);

            //app.UpdateQualityAI(Items);

            System.Console.ReadKey();

        }

        public void UpdateQuality(IList<Item> Items)
        {
            ManageDecreaseSellIn(Items);

            ManageCommonItems(Items);

            ManageBries(Items);

            ManageBackstagePasses(Items);

        }

        private static void ManageBackstagePasses(IList<Item> Items)
        {
            var BackstagePasses = Items.Where(i => i.Name == "Backstage passes to a TAFKAL80ETC concert");
            foreach (var item in BackstagePasses)
            {
                if (item.SellIn < 0)
                {
                    item.Quality = 0;
                }
                else
                {
                    if (item.Quality < 50) item.Quality++;
                    if (item.SellIn < 10 && item.Quality < 50) item.Quality++;
                    if (item.SellIn < 5 && item.Quality < 50) item.Quality++;
                }
            }
        }

        private static void ManageBries(IList<Item> Items)
        {
            var Bries = Items.Where(i => i.Name == "Aged Brie");
            foreach (var item in Bries)
            {
                if (item.Quality < 50)
                {
                    item.Quality++;
                }
                if (item.SellIn < 0 && item.Quality < 50)
                {
                    item.Quality++;
                }
            }
        }

        private static void ManageCommonItems(IList<Item> Items)
        {
            var commonItems = Items.Where(i =>
                            i.Name != "Aged Brie" &&
                            i.Name != "Backstage passes to a TAFKAL80ETC concert" &&
                            i.Name != "Sulfuras, Hand of Ragnaros");

            foreach (var item in commonItems)
            {
                if (item.Quality > 0)
                {
                    item.Quality--;
                }
                if (item.SellIn < 0 && item.Quality > 0)
                {
                    item.Quality--;
                }
            }
        }

        private static void ManageDecreaseSellIn(IList<Item> Items)
        {
            var decreaseSellIn = Items.Where(i => i.Name != "Sulfuras, Hand of Ragnaros");
            foreach (var item in decreaseSellIn)
            {
                item.SellIn--;
            }
        }

        private static void UpdateQualityAI(IList<Item> items)
        {
            // Una sola pasada por la lista: Máximo rendimiento, cero memoria extra
            foreach (var item in items)
            {
                // 1. Modificar el SellIn (Regla general)
                if (item.Name != "Sulfuras, Hand of Ragnaros")
                {
                    item.SellIn--;
                }

                // 2. Modificar la Calidad según el tipo de artículo (Pattern Matching de C#)
                switch (item.Name)
                {
                    case "Aged Brie":
                        if (item.Quality < 50) item.Quality++;
                        if (item.SellIn < 0 && item.Quality < 50) item.Quality++;
                        break;

                    case "Backstage passes to a TAFKAL80ETC concert":
                        // Aquí el orden del SellIn coincide exactamente con el original
                        if (item.SellIn < 0)
                        {
                            item.Quality = 0;
                        }
                        else
                        {
                            if (item.Quality < 50) item.Quality++;
                            if (item.SellIn < 10 && item.Quality < 50) item.Quality++;
                            if (item.SellIn < 5 && item.Quality < 50) item.Quality++;
                        }
                        break;

                    case "Sulfuras, Hand of Ragnaros":
                        // No hace nada, es inmuta ble
                        break;

                    default: // Artículos comunes
                        if (item.Quality > 0) item.Quality--;
                        if (item.SellIn < 0 && item.Quality > 0) item.Quality--;
                        break;
                }
            }
        }
    }
}

    
