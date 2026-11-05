using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ_CategoryGrouping
{
    public class ProductManager
    {
        private List<Product> products = new List<Product>
        {
            new Product("Наушники", 3500m, "Электроника"),
            new Product("Мышь", 1500m, "Электроника"),
            new Product("Клавиатура", 4500m, "Электроника"),
            new Product("Монитор", 25000m, "Электроника"),
            new Product("Книга по C#", 1200m, "Литература"),
            new Product("Фантастика", 700m, "Литература"),
            new Product("Рюкзак", 4000m, "Аксессуары"),
            new Product("Ремень", 2000m, "Аксессуары")
        };

        public void ShowCategorySummary()
        {
            var summary = products
                .GroupBy(p => p.Category)
                .Select(g => new
                {
                    Category = g.Key,
                    Count = g.Count(),
                    AveragePrice = g.Average(p => p.Price)
                });

            Console.WriteLine("=== Итоговая сводка по категориям ===");
            foreach (var item in summary)
            {
                Console.WriteLine($"Категория: {item.Category} | Количество: {item.Count} | Средняя цена: {item.AveragePrice:F2} руб.");
            }
        }

        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        public void PrintAll()
        {
            Console.WriteLine("=== Все товары ===");
            foreach (var p in products)
            {
                Console.WriteLine(p);
            }
        }
    }
}