using Products.Data.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit;
using NUnit.Framework;

namespace Products.Data.Tests
{
    [TestFixture]
    public class ProductDataTests
    {
        [Test]
        [TestCaseSource("GetDataSources")]
        public void ProductCRUD(ProductDataConfiguration config)
        {
            Console.WriteLine("Creating data source from config: " + config.Type + " cache: " + config.UseCache);
            IProductData data = ProductStorageFactory.GetProductData(config);

            Console.WriteLine("Testing Create, Read, Update and Delete with " + data.ToString());
            var product = Resources.GetProduct();
            int id = data.StoreProduct(product);
            
            Assert.NotNull(id);
            Assert.True(id > 0);
            Console.WriteLine("Create Passed");

            var returned = data.GetProductById(id);

            Assert.AreEqual(id, returned.ProductID);
            Assert.AreEqual(product.Name, returned.Name);
            Assert.AreEqual(product.SalePrice, returned.SalePrice);
            Assert.AreEqual(product.PurchasePrice, returned.PurchasePrice);
            Console.WriteLine("Read Passed");

            data.DeleteProduct(id);

            returned = data.GetProductById(id);
            Assert.Null(returned);
            Console.WriteLine("Delete Passed");
        }

        [Test]
        [TestCaseSource("GetDataSources")]
        public void InventoryCRUD(ProductDataConfiguration config)
        {
            Console.WriteLine("Creating data source from config: " + config.Type + " cache: " + config.UseCache);
            IProductData data = ProductStorageFactory.GetProductData(config);

            Console.WriteLine("Testing Create, Read, Update and Delete with " + data.ToString());
            var product = Resources.GetProduct();
            int id = data.StoreProduct(product);

            Assert.NotNull(id);
            Assert.True(id > 0);
            Console.WriteLine("Create Passed");

            data.SetInventory(id, 100);
            var returned = data.GetProductById(id);
            Assert.AreEqual(100, returned.Inventory);
            data.UpdateInventory(id, -2);
            returned = data.GetProductById(id);
            Assert.AreEqual(98, returned.Inventory);
            Console.WriteLine("Updated Passed");

            data.DeleteProduct(id);

            returned = data.GetProductById(id);
            Assert.Null(returned);
            Console.WriteLine("Delete Passed");
        }

        public IEnumerable<ProductDataConfiguration> GetDataSources()
        {
            return new List<ProductDataConfiguration>
            {
                Settings.MySqlWithCacheConfig,
                Settings.MySqlWithoutCacheConfig,
                //Settings.SqlServerWithCacheConfig,
                //Settings.SqlServerWithoutCacheConfig,
                Settings.XmlWithCacheConfig,
                Settings.XmlWithoutCacheConfig,
                Settings.RuntimeConfig
            };
        }
    }
}
