using MySql.Data.MySqlClient;
using Products.Data.Models;
using Products.Data.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Data.Storage.MySql
{
    internal class MySqlProductData : IProductData 
    {
        String ConnectionString { get; set; }

        public MySqlProductData(String connectionString)
        {
            if (connectionString == null) throw new ArgumentNullException("connectionString");

            ConnectionString = connectionString;
            using (MySqlProductsDb Db = new MySqlProductsDb(ConnectionString))
            {
                if (!Db.Database.Exists() || !Db.Database.CompatibleWithModel(true))
                {
                    Db.Database.Delete();
                    Db.Database.Create();
                }
            }
        }

        public IEnumerable<Product> GetAllProducts()
        {
            using (MySqlProductsDb Db = new MySqlProductsDb(ConnectionString))
            {
                return Db.Products.ToList();
            }
        }

        public Product GetProductById(int productId)
        {
            using (MySqlProductsDb Db = new MySqlProductsDb(ConnectionString))
            {
                return Db.Products.Where(x => x.ProductID == productId).FirstOrDefault();
            }
        }

        public int StoreProduct(Product product)
        {
            using (MySqlProductsDb Db = new MySqlProductsDb(ConnectionString))
            {
                Db.Products.Add(product);
                Db.SaveChanges();
            }
            return product.ProductID;
        }

        public void UpdateInventory(int productId, int diff)
        {
            var prod = GetProductById(productId);
            using (MySqlProductsDb Db = new MySqlProductsDb(ConnectionString))
            {
                if (prod != null)
                {
                    Db.Products.Attach(prod);
                    prod.Inventory += diff;
                    Db.Entry(prod).Property("Inventory").IsModified = true;
                    Db.SaveChanges();
                }
            }
        }

        public void SetInventory(int productId, int quantity)
        {
            var prod = GetProductById(productId);
            using (MySqlProductsDb Db = new MySqlProductsDb(ConnectionString))
            {
                if (prod != null)
                {
                    Db.Products.Attach(prod);
                    prod.Inventory = quantity;
                    Db.Entry(prod).Property("Inventory").IsModified = true;
                    Db.SaveChanges();
                }
            }
        }

        public void DeleteProduct(int productId)
        {
            using (MySqlProductsDb Db = new MySqlProductsDb(ConnectionString))
            {
                var prod = new Product() { ProductID = productId };
                Db.Products.Attach(prod);
                Db.Products.Remove(prod);
                Db.SaveChanges();
            }
        }

        public void Dispose()
        {

        }

        public override string ToString()
        {
            return "MySql Products Database";
        }
    }
}
