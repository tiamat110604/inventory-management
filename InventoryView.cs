using System;
using InventoryApp.Services;

namespace InventoryApp.Views
{
    public class InventoryView
    {
        private InventoryService service;

        public InventoryView()
        {
            service = new InventoryService();
        }

        public void Run()
        {
            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine("\n==== INVENTORY MENU ====");
                Console.WriteLine("1. View Inventory");
                Console.WriteLine("2. Update Stock");
                Console.WriteLine("3. Reset Inventory");
                Console.WriteLine("4. Exit");
                Console.Write("Select option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ViewInventory();
                        break;

                    case "2":
                        UpdateStock();
                        break;

                    case "3":
                        service.ResetInventory();
                        Console.WriteLine("Inventory has been reset.");
                        break;

                    case "4":
                        isRunning = false;
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
        }

        private void ViewInventory()
        {
            string[,] products = service.GetProducts();

            Console.WriteLine("\nCurrent Inventory:");
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"{i + 1}. {products[0, i]} - Stock: {products[1, i]}");
            }
        }

        private void UpdateStock()
        {
            ViewInventory();

            Console.Write("Enter product number (1-3): ");
            int productNumber = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter new stock quantity: ");
            int newStock = Convert.ToInt32(Console.ReadLine());

            service.UpdateStock(productNumber - 1, newStock);

            Console.WriteLine("Stock updated successfully.");
        }
    }
}
