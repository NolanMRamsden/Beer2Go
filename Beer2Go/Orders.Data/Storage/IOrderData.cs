using Orders.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Data.Storage
{
    public interface IOrderData : IDisposable
    {
        IEnumerable<Order> GetAllOrders();
        IEnumerable<Order> GetAllActiveOrders();
        Order GetOrderById(int orderid);

        int StoreOrder(Order order);
        void SetOrderStatus(int orderId, eOrderStatus status);

        void DeleteOrder(int orderId);
    }
}
