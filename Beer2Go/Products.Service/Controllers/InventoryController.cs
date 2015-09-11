using Products.Data.Models;
using Products.Data.Storage;
using Products.Service.DataBoundary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Products.Service.Controllers
{
    public class InventoryController : ApiController
    {
        private readonly IProductData productData;

        public InventoryController(IProductData data)
        {
            this.productData = data;
        }

        [HttpGet]
        [Route("api/Inventory")]
        public IEnumerable<Object> Get()
        {
            return productData.GetAllProducts().Select(x => new { x.ProductID, x.Inventory });
        }

        [HttpGet]
        [Route("api/Inventory")]
        public int Get([FromUri]int productId)
        {
            var product = productData.GetProductById(productId);
            return product == null ? -1 : product.Inventory;
        }

        [HttpPost]
        [Route("api/Inventory")]
        public IHttpActionResult Post([FromUri]int productId, [FromBody]int diff)
        {
            if (Get(productId) + diff < 0) return BadRequest();

            productData.UpdateInventory(productId, diff);
            return Ok();
        }

        [HttpPut]
        [Route("api/Inventory")]
        public IHttpActionResult Put([FromUri]int productId, [FromBody]int quantity)
        {
            if (quantity < 0) return BadRequest();
            productData.SetInventory(productId, quantity);
            return Ok();
        }
    }
}
