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
    public class MySqlTests : DataLayerTests
    {
        [TestInitialize]
        public void SetUp()
        {
            data = MemberStorageFactory.GetMemberData(MemberTest.mySqlConfig);
        }

        [TestMethod]
        public void MySqlCreateMember()
        {
            base.CreateMember();
        }

        [TestMethod]
        public void MySqlCreateMemberShip()
        {
            base.CreateMemberAndMemberShip();
        }

        [TestMethod]
        public void MySqlModifyLocation()
        {
            base.CreateMemberAndModifyLocation();
        }

    }
}
