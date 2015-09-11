using Members.Data.Storage;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Members.Tests.DataLayer
{
    public class DataLayerTests
    {
        protected IMemberData data;

        protected void CreateMember()
        {
            var member = MemberTest.GetMember();
            int id = data.StoreMember(member);

            Assert.IsNotNull(id);

            var retrieved = data.GetMemberById(id);

            Assert.AreEqual(id, retrieved.MemberId);
            Assert.AreEqual(member.Name, retrieved.Name);
        }

        protected void CreateMemberAndMemberShip()
        {
            var member = MemberTest.GetMember();
            int id = data.StoreMember(member);
            
            Assert.IsNotNull(id);

            data.CreateMemberShip(id);
            var retrieved = data.GetMemberById(id);

            Assert.IsNotNull(retrieved.Membership);
            Assert.AreEqual(id, retrieved.MemberId);
            Assert.AreEqual(member.Name, retrieved.Name);
        }

        protected void CreateMemberAndModifyLocation()
        {
            var member = MemberTest.GetMember();
            int id = data.StoreMember(member);

            Assert.IsNotNull(id);

            data.SetMemberLocation(id, 100, 50);

            var retrieved = data.GetMemberById(id);

            Assert.AreEqual(100, retrieved.LastLatitude);
            Assert.AreEqual(50, retrieved.LastLongitude);

            Assert.AreEqual(id, retrieved.MemberId);
            Assert.AreEqual(member.Name, retrieved.Name);
        }
    }
}
