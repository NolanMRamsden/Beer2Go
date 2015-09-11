using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Location.Data.Storage;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GoogleApi.Contracts.Models;

namespace Location.Tests.StorageTests
{
    public class TruckLocationStorageBaseTests
    {
        protected ITruckLocationStorage storage;

        public void SingleTruckOverrideLocation()
        {
            GeoLocation l1 = new GeoLocation("123 Fake Street");
            GeoLocation l2 = new GeoLocation("456 Fake Street");

            Assert.IsNull(storage.GetLocation(1));
            
            storage.LogLocation(1, l1);
            Assert.AreEqual(l1, storage.GetLocation(1));

            storage.LogLocation(1, l2);
            Assert.AreEqual(l2, storage.GetLocation(1));
        }

        public void MultipeTrucksMultipleLocations()
        {
            GeoLocation l1 = new GeoLocation("123 Fake Street");
            GeoLocation l2 = new GeoLocation("456 Fake Street");
            GeoLocation l3 = new GeoLocation("789 Fake Street");

            Assert.IsNull(storage.GetLocation(1));
            Assert.IsNull(storage.GetLocation(2));

            storage.LogLocation(1, l1);
            Assert.AreEqual(l1, storage.GetLocation(1));
            Assert.IsNull(storage.GetLocation(2));

            storage.LogLocation(2, l2);
            Assert.AreEqual(l1, storage.GetLocation(1));
            Assert.AreEqual(l2, storage.GetLocation(2));

            storage.LogLocation(1, l3);
            Assert.AreEqual(l3, storage.GetLocation(1));
            Assert.AreEqual(l2, storage.GetLocation(2));
        }

        protected void CleanUp()
        {
            storage = null;
        }
    }
}
