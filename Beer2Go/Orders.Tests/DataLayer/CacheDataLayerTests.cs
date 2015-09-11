using Microsoft.VisualStudio.TestTools.UnitTesting;
using Orders.Data.Models;
using Orders.Data.Storage;
using Orders.Data.Storage.Cache;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Tests.DataLayer
{
    [TestClass]
    public class CacheDataLayerTests : DataLayerTests
    {
        OrderCache cache;

        [TestInitialize]
        public void SetUp()
        {
            data = cache = OrderStorageFactory.GetOrderData(cacheConfiguration) as OrderCache;
        }

        [TestMethod]
        public void CacheInsertAndDeleteOrders()
        {
            base.InsertAndDeleteOrders();
        }

        [TestMethod]
        public void CacheInsertAndRetrieveOrders()
        {
            base.InsertAndRetrieveOrders();
        }

        [TestMethod]
        public void CacheInsertAndModifyStatus()
        {
            base.InsertAndModifyStatus();
        }

        [TestMethod]
        public void CacheSetStatusToDeliveredSetsDeliveredAt()
        {
            base.SettingStatusToDeliveredSetsDeliveredAt();
        }

        [TestMethod]
        public void CacheCreateStoreRetrieveWithConnectionSever()
        {
            int before = data.GetAllOrders().Count();
            data.StoreOrder(newOrder);
            File.Delete(cacheConfiguration.FilePath); //The select shouldnt hit data store anyways
            var product = data.GetOrderById(newOrder.OrderID);

            Assert.IsTrue(comparer.Equals(product, newOrder), "matching product not found after insert");
        }

        [TestMethod]
        public void CacheCreateStoreMissRetrieveWithConnectionSever()
        {
            int before = data.GetAllOrders().Count();
            data.StoreOrder(newOrder);
            File.Delete(cacheConfiguration.FilePath);
            try
            {
                var product = data.GetOrderById(newOrder.OrderID + 1);
                Assert.Fail("Cache did not check for product in datastore on miss");
            }
            catch (Exception) { }
        }

        [TestCleanup]
        public void CleanUp()
        {
            if (File.Exists(cacheConfiguration.FilePath))
                File.Delete(cacheConfiguration.FilePath);
        }
    }
}
