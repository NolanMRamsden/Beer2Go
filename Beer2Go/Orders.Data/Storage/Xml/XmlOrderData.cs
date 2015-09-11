using Orders.Data.Models;
using Orders.Data.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Xml.Serialization;

namespace Orders.Data.Storage.Xml
{
    internal class XmlOrderData : IOrderData
    {
        String FilePath { get; set; }
        XmlSerializer Serializer { get; set; }

        public XmlOrderData(String filePath)
        {
            if (filePath == null) throw new ArgumentNullException("filePath");
            if (String.IsNullOrWhiteSpace(filePath)) throw new ArgumentException("filePath cannot be whitespace");

            Serializer = new XmlSerializer(typeof(List<Order>), new Type[] {  });
            FilePath = filePath;
            InitXmlFile();
        }

        protected void InitXmlFile()
        {
            try
            {
                if(AllOrders().Count == 0)
                {
                    using (FileStream stream = File.OpenWrite(FilePath))
                    {
                        List<Order> list = new List<Order>();
                        Serializer.Serialize(stream, list);
                    }
                }
            }
            catch (InvalidOperationException)
            {
                using (FileStream stream = File.OpenWrite(FilePath))
                {
                    List<Order> list = new List<Order>();
                    Serializer.Serialize(stream, list);
                }
            }
            catch(FileNotFoundException)
            {
                File.Create(FilePath).Dispose();
                InitXmlFile();
            }
        }

        public IEnumerable<Order> GetAllActiveOrders()
        {
            return AllOrders().Where(o => o.Status == eOrderStatus.NEW);
        }

        public Order GetOrderById(int orderId)
        {
            return AllOrders().Where(o => o.OrderID == orderId).FirstOrDefault();
        }

        public int StoreOrder(Order order)
        {
            var orders = AllOrders();
            order.OrderID = DateTime.Now.Millisecond;
            orders.Add(order);
            using(FileStream stream = File.Open(FilePath,FileMode.Create))
            {
                Serializer.Serialize(stream, orders);
            }

            return order.OrderID;
        }

        public void SetOrderStatus(int orderId, eOrderStatus status)
        {
            List<Order> orders = AllOrders();
            Order o = orders.Where(x => x.OrderID == orderId).FirstOrDefault();
            if (o != null)
            {
                o.Status = status;
                if (status == eOrderStatus.DELIVERED) o.DeliveredAt = DateTime.Now;

                using (FileStream stream = File.Open(FilePath, FileMode.Create))
                {
                    Serializer.Serialize(stream, orders);
                }
            }
        }

        public void DeleteOrder(int orderId)
        {
            List<Order> orders = AllOrders();
            Order o = orders.Where(x => x.OrderID == orderId).FirstOrDefault();
            if (o != null)
            {
                orders.Remove(o);
                using (FileStream stream = File.Open(FilePath, FileMode.Create))
                {
                    Serializer.Serialize(stream, orders);
                }
            }
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return AllOrders();
        }

        private List<Order> AllOrders()
        {
            var orders = new List<Order>();
            using (FileStream stream = File.OpenRead(FilePath))
            {
                orders = (List<Order>)Serializer.Deserialize(stream);
            }
            return orders;
        }

        public void Dispose()
        {
            return;
        }

        public override string ToString()
        {
            return "Xml Orders Database";
        }
    }
}
