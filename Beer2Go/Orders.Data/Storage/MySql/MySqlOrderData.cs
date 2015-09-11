using Orders.Data.Models;
using Orders.Data.Storage;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Orders.Data.Storage.MySql
{
    internal class MySqlOrderData : IOrderData 
    {
        String ConnectionString { get; set; }

        public MySqlOrderData(String connectionString)
        {
            if (connectionString == null) throw new ArgumentNullException("connectionString");

            ConnectionString = connectionString;
            using (MySqlOrdersDb Db = new MySqlOrdersDb(ConnectionString))
            {
                if (!Db.Database.Exists() || !Db.Database.CompatibleWithModel(true))
                {
                    Db.Database.Delete();
                    Db.Database.Create();
                }
            }
        }

        public IEnumerable<Order> GetAllOrders()
        {
            using (MySqlOrdersDb Db = new MySqlOrdersDb(ConnectionString))
            {
                return Db.Orders.Include(o => o.OrderedProducts)
                                .ToList();
            }
        }

        public IEnumerable<Order> GetAllActiveOrders()
        {
            using (MySqlOrdersDb Db = new MySqlOrdersDb(ConnectionString))
            {
                return Db.Orders.Where(o => o.Status == eOrderStatus.NEW)
                                .Include(o => o.OrderedProducts)
                                .ToList();
            }
        }

        public Order GetOrderById(int orderid)
        {
            using (MySqlOrdersDb Db = new MySqlOrdersDb(ConnectionString))
            {
                return Db.Orders.Where(o => o.OrderID == orderid)
                                .Include(o => o.OrderedProducts)
                                .FirstOrDefault();
            }
        }

        public int StoreOrder(Order order)
        {
            using (MySqlOrdersDb Db = new MySqlOrdersDb(ConnectionString))
            {
                Db.Orders.Add(order);
                Db.SaveChanges();
            }

            return order.OrderID;
        }

        public void SetOrderStatus(int orderId, eOrderStatus status)
        {
            using (MySqlOrdersDb Db = new MySqlOrdersDb(ConnectionString))
            {
                var ord = GetOrderById(orderId);
                if (ord != null)
                {
                    Db.Orders.Attach(ord);
                    ord.Status = status;
                    if (status == eOrderStatus.DELIVERED)
                    {
                        ord.DeliveredAt = DateTime.Now;
                        Db.Entry(ord).Property("DeliveredAt").IsModified = true;
                    }
                    Db.Entry(ord).Property("Status").IsModified = true;
                    Db.SaveChanges();
                }
            }
        }

        public void DeleteOrder(int orderId)
        {
            using (MySqlOrdersDb Db = new MySqlOrdersDb(ConnectionString))
            {
                Order order = Db.Orders.Where(o => o.OrderID == orderId).FirstOrDefault();
                if (order == null) return;

                Db.ProductOrders.RemoveRange(order.OrderedProducts);
                Db.SaveChanges();

                Db.Orders.Remove(order);
                Db.SaveChanges();
            }
        }

        public void Dispose()
        {

        }

        public override string ToString()
        {
            return "MySql Orders Database";
        }
    }
}
