using Members.Data.Storage;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Members.Tests.DataLayer
{
    [Ignore]
    [TestClass]
    public class SqlServerTests : DataLayerTests
    {
        [TestInitialize]
        public void SetUp()
        {
            data = MemberStorageFactory.GetMemberData(MemberTest.sqlServerConfig);
        }

        [TestMethod]
        public void SqlServerCreateMember()
        {
            base.CreateMember();
        }

        [TestMethod]
        public void SqlServerCreateMemberShip()
        {
            base.CreateMemberAndMemberShip();
        }

        [TestMethod]
        public void SqlServerModifyLocation()
        {
            base.CreateMemberAndModifyLocation();
        }
    }
}
