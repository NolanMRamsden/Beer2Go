using Microsoft.VisualStudio.TestTools.UnitTesting;
using Orders.Data.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Tests.DataLayer
{
    [Ignore]
    [TestClass]
    public class SqlServerDataLayerTests : DataLayerTests
    {
        [TestInitialize]
        public void SetUp()
        {
            data = OrderStorageFactory.GetOrderData(sqlServerConfiguration);
            base.BaseSetUp();
        }

        [TestMethod]
        public void SqlServerInsertAndDeleteOrders()
        {
            base.InsertAndDeleteOrders();
        }

        [TestMethod]
        public void SqlServerInsertAndRetrieveOrders()
        {
            base.InsertAndRetrieveOrders();
        }

        [TestMethod]
        public void SqlServerInsertAndModifyStatus()
        {
            base.InsertAndModifyStatus();
        }

        [TestMethod]
        public void SqlServerSetStatusToDeliveredSetsDeliveredAt()
        {
            base.SettingStatusToDeliveredSetsDeliveredAt();
        }

        [TestCleanup]
        public void CleanUp()
        {
            if (data == null) throw new ObjectDisposedException("Still need this to clean up");
            if (data.GetOrderById(newOrder.OrderID) != null) data.DeleteOrder(newOrder.OrderID);
            if (data.GetOrderById(completedOrder.OrderID) != null) data.DeleteOrder(completedOrder.OrderID);
            if (data.GetOrderById(canceledOrder.OrderID) != null) data.DeleteOrder(canceledOrder.OrderID);
        }
    }
}