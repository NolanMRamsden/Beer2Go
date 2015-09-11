using Microsoft.VisualStudio.TestTools.UnitTesting;
using Orders.Data.Models;
using Orders.Data.Storage;
using Orders.Tests.Comparers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Tests.DataLayer
{
    [TestClass]
    public abstract class DataLayerTests : OrderTest
    {
        protected IOrderData data;
        protected Order newOrder;
        protected Order completedOrder;
        protected Order canceledOrder;
        protected IEqualityComparer<Order> comparer = new OrderComparer();

        [TestInitialize]
        public void BaseSetUp()
        {
            newOrder = OrderTest.GetNewOrder();
            completedOrder = OrderTest.GetDeliveredOrder();
            canceledOrder = OrderTest.GetCancelledOrder();
        }

        protected void InsertAndRetrieveOrders()
        {
            int before = data.GetAllOrders().Count();
            int activeBefore = data.GetAllActiveOrders().Count();
            data.StoreOrder(newOrder);
            Assert.AreEqual(++before, data.GetAllOrders().Count());
            Assert.AreEqual(++activeBefore, data.GetAllActiveOrders().Count());
            data.StoreOrder(completedOrder);
            Assert.AreEqual(++before, data.GetAllOrders().Count());
            Assert.AreEqual(activeBefore, data.GetAllActiveOrders().Count());
        }

        protected void InsertAndDeleteOrders()
        {
            int before = data.GetAllOrders().Count();
            int activeBefore = data.GetAllActiveOrders().Count();
            
            data.StoreOrder(newOrder);
            data.StoreOrder(completedOrder);
            Assert.AreEqual(before + 2, data.GetAllOrders().Count());
            Assert.AreEqual(activeBefore + 1, data.GetAllActiveOrders().Count());

            data.DeleteOrder(newOrder.OrderID);
            Assert.AreEqual(before + 1, data.GetAllOrders().Count());
            Assert.AreEqual(activeBefore, data.GetAllActiveOrders().Count());

            data.DeleteOrder(newOrder.OrderID);
            Assert.AreEqual(before + 1, data.GetAllOrders().Count());
            Assert.AreEqual(activeBefore, data.GetAllActiveOrders().Count());

            data.DeleteOrder(completedOrder.OrderID);
            Assert.AreEqual(before, data.GetAllOrders().Count());
            Assert.AreEqual(activeBefore, data.GetAllActiveOrders().Count());
        }

        protected void InsertAndModifyStatus()
        {
            int before = data.GetAllOrders().Count();
            int activeBefore = data.GetAllActiveOrders().Count();

            data.StoreOrder(newOrder);
            Assert.AreEqual(before + 1, data.GetAllOrders().Count());
            Assert.AreEqual(activeBefore + 1, data.GetAllActiveOrders().Count());

            data.SetOrderStatus(newOrder.OrderID, eOrderStatus.DELIVERED);
            Assert.AreEqual(before + 1, data.GetAllOrders().Count());
            Assert.AreEqual(activeBefore, data.GetAllActiveOrders().Count());
            Assert.AreEqual(eOrderStatus.DELIVERED, data.GetOrderById(newOrder.OrderID).Status);
        }

        protected void SettingStatusToDeliveredSetsDeliveredAt()
        {
            data.StoreOrder(newOrder);
            data.SetOrderStatus(newOrder.OrderID, eOrderStatus.DELIVERED);

            var order = data.GetOrderById(newOrder.OrderID);
            Assert.AreEqual(eOrderStatus.DELIVERED, order.Status);
            Assert.IsNotNull(order.DeliveredAt);
            System.Threading.Thread.Sleep(500);
            Assert.IsTrue(DateTime.Now.Subtract(order.DeliveredAt.Value).TotalSeconds >= 0);
        }

        [TestCleanup]
        public void BaseCleanUp()
        {
            if (data != null) data.Dispose();
            if (File.Exists(xmlConfiguration.FilePath)) File.Delete(xmlConfiguration.FilePath);
        }
    }
}
