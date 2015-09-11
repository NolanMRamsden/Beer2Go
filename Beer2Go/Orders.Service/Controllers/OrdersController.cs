using Orders.Contracts;
using Orders.Contracts.Models;
using Orders.Data.Models;
using Orders.Data.Storage;
using Orders.Service.DataBoundary;
using Service.Common.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Orders.Service.Controllers
{
    public class OrdersController : ApiController
    {
        private readonly IOrderData orderData;

        public OrdersController(IOrderData data)
        {
            orderData = data;
        }

        [HttpGet]
        [Route("api/Orders")]
        public IEnumerable<OrderDto> Get()
        {
            var orders = orderData.GetAllActiveOrders();
            var orderDtos = new List<OrderDto>();
            foreach (Order order in orders)
                orderDtos.Add(OrderComposer.OrderDtoFromOrderModel(order));

            return orderDtos;
        }

        [HttpGet]
        [Route("api/Orders")]
        public OrderDto Get([FromUri]int orderId)
        {
            Order order = orderData.GetOrderById(orderId);
            OrderDto orderDto = OrderComposer.OrderDtoFromOrderModel(order);

            return orderDto;
        }

        [HttpPut]
        [ValidateModel]
        [Route("api/Orders")]
        public int Put([FromBody]OrderDto order)
        {            
            Order orderModel = OrderExtractor.GetOrderFromDto(order);
            orderModel.Status = eOrderStatus.NEW;
            orderModel.SubmittedAt = DateTime.Now;
            return orderData.StoreOrder(orderModel);
        }

        [HttpDelete]
        [Route("api/Orders")]
        public IHttpActionResult Delete([FromUri]int orderId)
        {
            orderData.DeleteOrder(orderId);
            return Ok();
        }
    }
}
