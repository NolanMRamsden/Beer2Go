using Products.Data.Models;
using Products.Data.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Data.Storage.SqlServer
{
    internal class SqlServerProductData : IProductData
    {
        String ConnectionString { get; set; }

        public SqlServerProductData(String connectionString)
        {
            if (connectionString == null) throw new ArgumentNullException("connectionString");
            ConnectionString = connectionString;
            using (SqlServerProductsDb Db = new SqlServerProductsDb(ConnectionString))
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
            using (SqlServerProductsDb Db = new SqlServerProductsDb(ConnectionString))
            {
                return Db.Products.ToList();
            }
        }

        public Product GetProductById(int productId)
        {
            using (SqlServerProductsDb Db = new SqlServerProductsDb(ConnectionString))
            {
                return Db.Products.Where(x => x.ProductID == productId).FirstOrDefault();
            }
        }

        public int StoreProduct(Product product)
        {
            using (SqlServerProductsDb Db = new SqlServerProductsDb(ConnectionString))
            {
                Db.Products.Add(product);
                Db.SaveChanges();
            }
            return product.ProductID;
        }

        public void UpdateInventory(int productId, int diff)
        {
            using (SqlServerProductsDb Db = new SqlServerProductsDb(ConnectionString))
            {
                var prod = GetProductById(productId);
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
            using (SqlServerProductsDb Db = new SqlServerProductsDb(ConnectionString))
            {
                var prod = GetProductById(productId);
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
            using (SqlServerProductsDb Db = new SqlServerProductsDb(ConnectionString))
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
            return "SqlServer Products Database";
        }
    }
}
