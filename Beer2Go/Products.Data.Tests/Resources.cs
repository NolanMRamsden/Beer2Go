using Products.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Data.Tests
{
    public static class Resources
    {
        private static Random rand = new Random();

        public static Product GetProduct()
        {
            return GetProduct(0);
        }

        public static Product GetProduct(int inventory)
        {
            return GetProduct("Test Product", "A testing product of the six pack variety", inventory, rand.Next(5,15), rand.Next(15,25), 6);
        }

        public static Product GetProduct(String name, String description, int inventory, decimal purchasePrice, decimal salePrice, int units)
        {
            return new Product()
            {
                Name = name,
                Description = description,
                Inventory = inventory,
                PurchasePrice = salePrice,
                SalePrice = purchasePrice,
                UnitQuantity = units
            };
        }
    }
}
