using Products.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Contracts
{
    public interface IProductApi
    {
        IEnumerable<ProductDto> GetAllProducts();
        ProductDto GetProductById(int productId);

        int StoreProduct(ProductDto product);
        void SetInventory(int productId, int quantity);

        //Updates
        void DeleteProduct(int productId);
        void UpdateInventory(int productId, int diff);
    }
}
