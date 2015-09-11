using Microsoft.VisualStudio.TestTools.UnitTesting;
using Orders.Data.Storage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Tests.DataLayer
{
    [TestClass]
    public class XmlDataLayerTests : DataLayerTests
    {
        [TestInitialize]
        public void SetUp()
        {
            data = OrderStorageFactory.GetOrderData(xmlConfiguration);
        }

        [TestMethod]
        public void XmlInsertAndDeleteOrders()
        {
            base.InsertAndDeleteOrders();
        }

        [TestMethod]
        public void XmlInsertAndRetrieveOrders()
        {
            base.InsertAndRetrieveOrders();
        }

        [TestMethod]
        public void XmlInsertAndModifyStatus()
        {
            base.InsertAndModifyStatus();
        }

        [TestMethod]
        public void XmlSetStatusToDeliveredSetsDeliveredAt()
        {
            base.SettingStatusToDeliveredSetsDeliveredAt();
        }

        [TestCleanup]
        public void CleanUp()
        {
            if (File.Exists(cacheConfiguration.FilePath))
                File.Delete(cacheConfiguration.FilePath);
        }
    }
}
