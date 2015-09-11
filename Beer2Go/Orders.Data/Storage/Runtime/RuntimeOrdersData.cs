using Orders.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Data.Storage.Runtime
{
    public class RuntimeOrdersData : IOrderData
    {
        protected IDictionary<int,Order> Cache;
        protected Random random = new Random();

        public RuntimeOrdersData()
        {
            Cache = GetCache();
        }

        protected IDictionary<int, Order> GetCache()
        {
            return new Dictionary<int, Order>();
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return Cache.Values;
        }

        public IEnumerable<Order> GetAllActiveOrders()
        {
            return GetAllOrders().Where(o => o.Status == eOrderStatus.NEW);
        }

        public Order GetOrderById(int orderid)
        {
            if (Cache.ContainsKey(orderid))
                return Cache[orderid];
            return null;
        }

        public int StoreOrder(Order order)
        {
            order.OrderID = random.Next(0, 10000);
            Cache.Add(order.OrderID, order);
            return order.OrderID;
        }

        public void SetOrderStatus(int orderId, eOrderStatus status)
        {
            if (Cache.ContainsKey(orderId))
            {
                Cache[orderId].Status = status;
                if (status == eOrderStatus.DELIVERED) Cache[orderId].DeliveredAt = DateTime.Now;
            }
        }

        public void DeleteOrder(int orderId)
        {
            Cache.Remove(orderId);
        }

        public override string ToString()
        {
            return "Runtime Orders Storage";
        }

        public void Dispose()
        {
            Cache = null;
        }
    }
}
