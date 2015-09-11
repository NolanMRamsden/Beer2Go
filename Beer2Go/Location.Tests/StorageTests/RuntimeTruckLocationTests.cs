using Location.Data.Storage.RunTimeStorage;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Location.Tests.StorageTests
{
    [TestClass]
    public class RuntimeTruckLocationTests : TruckLocationStorageBaseTests
    {
        [TestInitialize]
        public void SetUp()
        {
            storage = new RunTimeTruckStorage();
        }

        [TestMethod]
        public void RuntimeSingleTruck()
        {
            base.SingleTruckOverrideLocation();
        }

        [TestMethod]
        public void RuntimeMultipeTrucksMultipleLocation()
        {
            base.MultipeTrucksMultipleLocations();
        }

        [TestCleanup]
        public void Cleanup()
        {
            base.CleanUp();
        }
    }
}
