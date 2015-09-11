using Products.Contracts.Models;
using Products.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Contracts.Tests
{
    public static class Resources
    {
        public const String UrlAtTest = @"http://beer2go-products.azurewebsites.net";

        static Random rand = new Random();

        public static ProductDto GetProductDto(decimal salePrice, decimal purchasePrice)
        {
            return GetProductDto("Test Product Dto", "This is the data transfer object", 0, salePrice, purchasePrice, 6);
        }

        public static ProductDto GetProductDto(int units)
        {
            return GetProductDto("Test Product Dto", "This is the data transfer object", 0, rand.Next(5,15), rand.Next(15,25), units);
        }

        public static ProductDto GetProductDto(String name, String description)
        {
            return GetProductDto(name, description, 0, rand.Next(5, 15), rand.Next(15, 25), 6);
        }

        public static ProductDto GetProductDto(String name, String description, int inventory, decimal purchasePrice, decimal salePrice, int units)
        {
            return new ProductDto()
            {
                Name = name,
                Description = description,
                Inventory = inventory,
                PurchasePrice = purchasePrice,
                SalePrice = salePrice,
                UnitQuantity = units
            };
        }

        public static Product GetProduct()
        {
            return GetProduct(0);
        }

        public static Product GetProduct(int inventory)
        {
            return GetProduct("Test Product", "A testing product of the six pack variety", inventory, rand.Next(5, 15), rand.Next(15, 25), 6);
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
