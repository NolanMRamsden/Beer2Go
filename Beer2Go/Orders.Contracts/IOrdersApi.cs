using Orders.Contracts.Models;
using Orders.Contracts.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Contracts
{
    public interface IOrdersApi
    {
        List<OrderDto> GetActiveOrders();
        OrderDto GetOrder(int orderId);
        int PutOrder(OrderDto dto);
        void SetOrderStatus(int orderId, OrderStatus status);
        void DeleteOrder(int orderId);
    }
}
