using Orders.Data.Models;
using Orders.Data.Storage;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Orders.Data.Storage.SqlServer
{
    internal class SqlServerOrderData : IOrderData
    {
        String ConnectionString { get; set; }

        public SqlServerOrderData(String connectionString)
        {
            if (connectionString == null) throw new ArgumentNullException("connectionString");

            ConnectionString = connectionString;
            using (SqlServerOrdersDb Db = new SqlServerOrdersDb(ConnectionString))
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
            using (SqlServerOrdersDb Db = new SqlServerOrdersDb(ConnectionString))
            {
                return Db.Orders.Include(o => o.OrderedProducts)
                                .ToList();
            }
        }

        public IEnumerable<Order> GetAllActiveOrders()
        {
            using (SqlServerOrdersDb Db = new SqlServerOrdersDb(ConnectionString))
            {
                return Db.Orders.Where(o => o.Status == eOrderStatus.NEW)
                                .Include(o => o.OrderedProducts)
                                .ToList();
            }
        }

        public Order GetOrderById(int orderId)
        {
            using (SqlServerOrdersDb Db = new SqlServerOrdersDb(ConnectionString))
            {
                return Db.Orders.Where(o => o.OrderID == orderId)
                                .Include(o => o.OrderedProducts)
                                .FirstOrDefault();
            }
        }

        public int StoreOrder(Order order)
        {
            using (SqlServerOrdersDb Db = new SqlServerOrdersDb(ConnectionString))
            {
                Db.Orders.Add(order);
                Db.SaveChanges();
            }

            return order.OrderID;
        }

        public void SetOrderStatus(int orderId, eOrderStatus status)
        {
            using (SqlServerOrdersDb Db = new SqlServerOrdersDb(ConnectionString))
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
            using (SqlServerOrdersDb Db = new SqlServerOrdersDb(ConnectionString))
            {
                Order order = Db.Orders.Where(o => o.OrderID == orderId).FirstOrDefault();
                if (order == null) return;
                foreach (var product in order.OrderedProducts)
                    Db.ProductOrders.Attach(product);
                Db.ProductOrders.RemoveRange(order.OrderedProducts);
                Db.SaveChanges();

                Db.Orders.Attach(order);
                Db.Orders.Remove(order);
                Db.SaveChanges();
            }
        }

        public void Dispose()
        {
            
        }

        public override string ToString()
        {
            return "SqlServer Orders Database";
        }
    }
}
