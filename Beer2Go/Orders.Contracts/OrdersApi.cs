using Orders.Contracts.Models;
using ApiConsumer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiConsumer.Requesters;
using Orders.Contracts.Requests;

namespace Orders.Contracts
{
    public class OrdersApi : IOrdersApi
    {
        private IApiRequester requester { get; set; }
        private String baseUrl { get; set; }

        public OrdersApi(String Url, IApiRequester apiRequester)
        {
            baseUrl = Url;
            requester = apiRequester;
        }

        public List<OrderDto> GetActiveOrders()
        {
            var request = new GetOrdersRequest(baseUrl);
            return requester.Get<List<OrderDto>>(request);
        }

        public OrderDto GetOrder(int orderId)
        {
            var request = new GetOrdersRequest(baseUrl) { OrderId = orderId };
            return requester.Get<OrderDto>(request);
        }

        public int PutOrder(OrderDto order)
        {
            var request = new PutOrderRequest(baseUrl, order);
            String response = requester.Put<OrderDto>(request);
            return Convert.ToInt32(response);
        }

        public void SetOrderStatus(int orderId, OrderStatus status)
        {
            var request = new SetStatusRequest(baseUrl, orderId, status);
            requester.Put<OrderStatus>(request);
        }

        public void DeleteOrder(int orderId)
        {
            var request = new DeleteOrderRequest(baseUrl) { OrderId = orderId };
            requester.Delete(request);
        }
    }
}
