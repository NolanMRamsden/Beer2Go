using Products.Contracts.Models;
using Products.Data.Models;
using Products.Data.Storage;
using Products.Service.DataBoundary;
using Service.Common.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Products.Service.Controllers
{
    public class ProductController : ApiController
    {
        private readonly IProductData productData;

        public ProductController(IProductData data)
        {
            this.productData = data;
        }

        [HttpGet]
        [RestrictDomains("ProductGetDomains")]
        [Route("api/Products")]
        public IEnumerable<ProductDto> Get()
        {
            var products = productData.GetAllProducts();
            var prods = new List<ProductDto>();
            foreach (var p in products)
                prods.Add(ProductComposer.DtoFromProduct(p));

            return prods;
        }

        [HttpGet]
        [RestrictDomains]
        [Route("api/Products")]
        public ProductDto Get([FromUri]int productId)
        {
            return ProductComposer.DtoFromProduct(productData.GetProductById(productId));
        }

        [HttpPut]
        [ValidateModel]
        [RestrictDomains]
        [Route("api/Products")]
        public int Put([FromBody]ProductDto product)
        {
            var prod = ProductComposer.ProductFromDto(product);
            return productData.StoreProduct(prod);
        }

        [HttpDelete]
        [RestrictDomains]
        [Route("api/Products")]
        public void Delete([FromUri]int productId)
        {
            productData.DeleteProduct(productId);
        }
    }
}
