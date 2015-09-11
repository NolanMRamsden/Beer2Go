using Products.Data.Models;
using Products.Data.Storage;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Data.Storage.Cache
{
    public class ProductCache : IProductData, IDisposable
    {
        protected IProductData DataStore;
        protected IDictionary<int,Product> Cache;

        public ProductCache(IProductData dataStore)
        {
            DataStore = dataStore;
            Cache = GetCache();
        }

        protected IDictionary<int, Product> GetCache()
        {
            return new Dictionary<int, Product>();
        }

        public virtual IEnumerable<Product> GetAllProducts()
        {
            var products = DataStore.GetAllProducts();
            foreach (var product in products)
            {
                if (Cache.ContainsKey(product.ProductID))
                {
                    Cache[product.ProductID] = product;
                }
                else
                {
                    Cache.Add(product.ProductID, product);
                }
            }
            return products;
        }

        public virtual Product GetProductById(int productId)
        {
            if (Cache.ContainsKey(productId))
                return Cache[productId];
            var product = DataStore.GetProductById(productId);
            if (product != null)
            {
                Cache.Add(product.ProductID, product);
            }
            return product;
        }

        public virtual int StoreProduct(Product product)
        {
            DataStore.StoreProduct(product);
            Cache.Add(product.ProductID, product);
           
            return product.ProductID;
        }

        public virtual void UpdateInventory(int productId, int diff)
        {
            Product p;
            DataStore.UpdateInventory(productId, diff);
            if (Cache.ContainsKey(productId))
            {
                Cache[productId].Inventory += diff;
            }
            else if ((p = DataStore.GetProductById(productId)) != null)
            {
                Cache.Add(p.ProductID, p);
            }
        }

        public void SetInventory(int productId, int quantity)
        {
            Product p;
            DataStore.SetInventory(productId, quantity);
            if (Cache.ContainsKey(productId))
            {
                Cache[productId].Inventory = quantity;
            }
            else if ((p = DataStore.GetProductById(productId)) != null)
            {
                Cache.Add(p.ProductID, p);
            }
        }

        public virtual void DeleteProduct(int productId)
        {
            DataStore.DeleteProduct(productId);
            Cache.Remove(productId);
        }

        public override string ToString()
        {
            return DataStore.ToString();
        }

        public void Dispose()
        {
            Cache = null;
        }
    }
}
