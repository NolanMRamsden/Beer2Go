using Products.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Data.Storage
{
    public interface IProductData : IDisposable
    {
        //Get
        IEnumerable<Product> GetAllProducts();
        Product GetProductById(int productId);

        //Set
        int StoreProduct(Product product);
        void SetInventory(int productId, int quantity);

        //Updates
        void DeleteProduct(int productId);
        void UpdateInventory(int productId, int diff);

    }
}
