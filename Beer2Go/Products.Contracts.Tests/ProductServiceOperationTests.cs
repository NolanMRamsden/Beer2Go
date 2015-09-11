using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit;
using NUnit.Framework;
using ApiConsumer.Requesters;
using Products.Contracts.Models;

namespace Products.Contracts.Tests
{
    [TestFixture]
    public class ProductServiceOperationTests
    {
        IProductApi api;
        private int Id;

        [TestFixtureSetUp]
        public void Init()
        {
            api = new ProductApi(Resources.UrlAtTest, new JsonApiRequester());
        }

        [Test]
        public void StoreProduct()
        {
            var product = new ProductDto()
                {
                    Name = "Phillips Blue Buck", UnitQuantity = 6, PurchasePrice = 16.99m, SalePrice = 13.99m, Inventory = 0
                };

            Id = api.StoreProduct(product);

            Assert.True(Id > 0);
            Assert.NotNull(api.GetProductById(Id));
        }

        [Test]
        public void DeleteProduct()
        {
            StoreProduct();

            api.DeleteProduct(Id);

            Assert.IsNull(api.GetProductById(Id));
        }

        [Test]
        public void UpdateInventory()
        {
            StoreProduct();

            api.SetInventory(Id, 100);

            Assert.AreEqual(100, api.GetProductById(Id).Inventory);

            api.UpdateInventory(Id, -1);

            Assert.AreEqual(99, api.GetProductById(Id).Inventory);
        }
    }
}
