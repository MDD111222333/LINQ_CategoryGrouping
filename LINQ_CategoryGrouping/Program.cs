using System;

namespace LINQ_CategoryGrouping
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager manager = new ProductManager();

            Console.WriteLine("=== Начальное состояние каталога ===");
            manager.PrintAll();

            Console.WriteLine();
            manager.ShowCategorySummary();

            Console.WriteLine("\n=== Интерактивный режим ===");

            while (true)
            {
                try
                {
                    Console.WriteLine("\n1. Показать сводку по категориям (GroupBy)");
                    Console.WriteLine("2. Добавить новый товар");
                    Console.WriteLine("3. Показать все товары");
                    Console.Write("Выберите действие (или 'stop' для выхода): ");
                    string choice = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(choice) || choice.Trim().ToLower() == "stop")
                    {
                        break;
                    }

                    if (choice == "1")
                    {
                        manager.ShowCategorySummary();
                    }
                    else if (choice == "2")
                    {
                        Console.Write("Введите название товара: ");
                        string name = Console.ReadLine() ?? "";
                        Console.Write("Введите цену товара: ");
                        decimal price = decimal.Parse(Console.ReadLine() ?? "0");
                        Console.Write("Введите категорию: ");
                        string category = Console.ReadLine() ?? "";

                        if (!string.IsNullOrWhiteSpace(name) && !string.IsNullOrWhiteSpace(category))
                        {
                            manager.AddProduct(new Product(name, price, category));
                            Console.WriteLine("Товар успешно добавлен в каталог.");
                        }
                    }
                    else if (choice == "3")
                    {
                        manager.PrintAll();
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ошибка: введено некорректное число.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }
            }
        }
    }
}