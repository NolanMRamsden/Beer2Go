using ApiConsumer.Requesters;
using Products.Contracts.Models;
using Products.Contracts.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Contracts
{
    public class ProductApi : IProductApi
    {
        String urlBase;
        IApiRequester requester;

        public ProductApi(String urlBase, IApiRequester requester)
        {
            this.urlBase = urlBase;
            this.requester = requester;
        }

        public IEnumerable<ProductDto> GetAllProducts()
        {
            return requester.Get<List<ProductDto>>(new GetProductRequest(urlBase));
        }

        public ProductDto GetProductById(int productId)
        {
            return requester.Get<ProductDto>(new GetProductRequest(urlBase) { ProductId = productId });
        }

        public int StoreProduct(ProductDto product)
        {
            String response = requester.Put<ProductDto>(new PutProductRequest(urlBase, product));
            return Convert.ToInt32(response);
        }

        public void SetInventory(int productId, int quantity)
        {
            requester.Put<int>(new SetInventoryRequest(urlBase, productId, quantity));
        }

        public void DeleteProduct(int productId)
        {
            requester.Delete(new DeleteProductRequest(urlBase) { ProductId = productId });
        }

        public void UpdateInventory(int productId, int diff)
        {
            requester.Post<int>(new SetInventoryRequest(urlBase, productId, diff));
        }
    }
}
