using System;

namespace InventoryApp.Services
{
    public class InventoryService
    {
        private string[,] products;
        private int[] initialStock;

        public InventoryService()
        {
            products = new string[2, 3];
            products[0, 0] = "Apples";
            products[0, 1] = "Milk";
            products[0, 2] = "Bread";

            products[1, 0] = "10";
            products[1, 1] = "5";
            products[1, 2] = "20";

            initialStock = new int[3];
            initialStock[0] = 10;
            initialStock[1] = 5;
            initialStock[2] = 20;
        }

        public string[,] GetProducts()
        {
            return products;
        }

        public void UpdateStock(int productIndex, int newStock)
        {
            products[1, productIndex] = newStock.ToString();
        }

        public void ResetInventory()
        {
            for (int i = 0; i < 3; i++)
            {
                products[1, i] = initialStock[i].ToString();
            }
        }
    }
}
