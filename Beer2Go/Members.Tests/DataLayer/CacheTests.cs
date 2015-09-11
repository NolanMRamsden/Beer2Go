using Members.Data.Storage;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Members.Tests.DataLayer
{
    [TestClass]
    public class CacheTests : DataLayerTests
    {
        [TestInitialize]
        public void SetUp()
        {
            data = MemberStorageFactory.GetMemberData(MemberTest.cacheConfig);
        }

        [TestMethod]
        public void CacheCreateMember()
        {
            base.CreateMember();
        }

        [TestMethod]
        public void CacheCreateMemberShip()
        {
            base.CreateMemberAndMemberShip();
        }

        [TestMethod]
        public void CacheModifyLocation()
        {
            base.CreateMemberAndModifyLocation();
        }

    }
}
