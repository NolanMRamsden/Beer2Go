using Orders.Data.Models;
using Orders.Data.Storage;
using Orders.Service.DataBoundary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Orders.Service.Controllers
{
    public class OrderManagementController : ApiController
    {
        private readonly IOrderData orderData;

        public OrderManagementController(IOrderData data)
        {
            orderData = data;
        }

        [HttpGet]
        [Route("api/OrderManagement")]
        public eOrderStatus Get([FromUri]int orderId)
        {
            return orderData.GetOrderById(orderId).Status;
        }

        [HttpPut]
        [Route("api/OrderManagement")]
        public IHttpActionResult Put([FromUri]int orderId, [FromBody]eOrderStatus status)
        {
            orderData.SetOrderStatus(orderId, status);
            return Ok();
        }
    }
}
