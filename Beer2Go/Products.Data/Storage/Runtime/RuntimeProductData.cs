using Products.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Data.Storage.Runtime
{
    public class RuntimeProductData : IProductData
    {
        protected IDictionary<int,Product> Cache;
        protected Random random = new Random();

        public RuntimeProductData()
        {
            Cache = GetCache();
        }

        protected IDictionary<int, Product> GetCache()
        {
            return new Dictionary<int, Product>();
        }

        public virtual IEnumerable<Product> GetAllProducts()
        {
            return Cache.Values;
        }

        public virtual Product GetProductById(int productId)
        {
            if (Cache.ContainsKey(productId))
                return Cache[productId];
            return null;
        }

        public virtual int StoreProduct(Product product)
        {
            product.ProductID = random.Next(0, 10000);
            Cache.Add(product.ProductID, product);

            return product.ProductID;
        }

        public virtual void UpdateInventory(int productId, int diff)
        {
            if (Cache.ContainsKey(productId))
            {
                Cache[productId].Inventory += diff;
            }
        }

        public void SetInventory(int productId, int quantity)
        {
            if (Cache.ContainsKey(productId))
            {
                Cache[productId].Inventory = quantity;
            }
        }

        public virtual void DeleteProduct(int productId)
        {
            Cache.Remove(productId);
        }

        public override string ToString()
        {
            return "Runtime Products Storage";
        }

        public void Dispose()
        {
            Cache = null;
        }
    }
}
