using Microsoft.VisualStudio.TestTools.UnitTesting;
using Orders.Data.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Tests.DataLayer
{
    [TestClass]
    public class MySqlDataLayerTests : DataLayerTests
    {
        [TestInitialize]
        public void SetUp()
        {
            data = OrderStorageFactory.GetOrderData(mySqlConfiguration);
            base.BaseSetUp();
        }

        [TestMethod]
        public void MySqlInsertAndDeleteOrders()
        {
            base.InsertAndDeleteOrders();
        }

        [TestMethod]
        public void MySqlInsertAndRetrieveOrders()
        {
            base.InsertAndRetrieveOrders();
        }

        [TestMethod]
        public void MySqlInsertAndModifyStatus()
        {
            base.InsertAndModifyStatus();
        }

        [TestMethod]
        public void MySqlSetStatusToDeliveredSetsDeliveredAt()
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

