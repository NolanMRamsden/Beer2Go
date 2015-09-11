using Orders.Data.Storage;
using Orders.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Data.Storage.Cache
{
    public class OrderCache : IOrderData, IDisposable
    {
        protected IOrderData DataStore;
        protected IDictionary<int,Order> Cache;

        public OrderCache(IOrderData dataStore)
        {
            DataStore = dataStore;
            Cache = GetCache();
        }

        protected IDictionary<int, Order> GetCache()
        {
            return new Dictionary<int, Order>();
        }

        public IEnumerable<Order> GetAllOrders()
        {
            var orders = DataStore.GetAllOrders();
            RefreshCache(orders);
            return orders.ToList();
        }

        public IEnumerable<Order> GetAllActiveOrders()
        {
            var orders = DataStore.GetAllActiveOrders();
            RefreshCache(orders);
            return orders.ToList();
        }

        public Order GetOrderById(int orderid)
        {
            if (Cache.ContainsKey(orderid))
                return Cache[orderid];
            var order = DataStore.GetOrderById(orderid);
            if (order != null)
            {
                Cache.Add(order.OrderID, order);
            }
            return order;
        }

        public int StoreOrder(Order order)
        {
            DataStore.StoreOrder(order);
            Cache.Add(order.OrderID, order);

            return order.OrderID;
        }

        public void SetOrderStatus(int orderId, eOrderStatus status)
        {
            DataStore.SetOrderStatus(orderId, status);
            if (Cache.ContainsKey(orderId))
            {
                Cache[orderId].Status = status;
                if (status == eOrderStatus.DELIVERED) Cache[orderId].DeliveredAt = DateTime.Now;
            }
            else
            {
                Cache.Add(orderId, DataStore.GetOrderById(orderId));
            }
        }

        public void DeleteOrder(int orderId)
        {
            DataStore.DeleteOrder(orderId);
            Cache.Remove(orderId);
        }

        public override string ToString()
        {
            return DataStore.ToString();
        }

        public void Dispose()
        {
            Cache = null;
        }

        private void RefreshCache(IEnumerable<Order> orders)
        {
            foreach (var order in orders)
            {
                if (Cache.ContainsKey(order.OrderID))
                {
                    Cache[order.OrderID] = order;
                }
                else
                {
                    Cache.Add(order.OrderID, order);
                }
            }
        }
    }
}
