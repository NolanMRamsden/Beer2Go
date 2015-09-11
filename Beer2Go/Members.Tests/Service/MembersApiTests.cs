using ApiConsumer.Requesters;
using Members.Contracts;
using Members.Contracts.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Members.Tests.Service
{
    [TestClass]
    public class MembersApiTests
    {
        const String urlAtTest = @"http://beer2go-members.azurewebsites.net/";

        IMemberApi jsonApi;
        IMemberApi xmlApi;

        [TestInitialize]
        public void SetUp()
        {
            jsonApi = new MemberApi(urlAtTest, new JsonApiRequester());
            xmlApi = new MemberApi(urlAtTest, new XmlRequester());
        }

        [TestMethod]
        public void MembersSanityTest()
        {
            var member = new MemberDto()
            {
                Name = "John Doe",
                PhoneNumber = "6042721430",
                LastLatitude = 0,
                LastLongitude = 0
            };

            int id = jsonApi.StoreMember(member);

            Assert.IsNotNull(id);
            Assert.IsTrue(id > 0);

            var returnedMember = jsonApi.GetMemberById(id);

            Assert.AreEqual(member.Name, returnedMember.Name);

            jsonApi.SetMemberLocation(id, 50, 25);
            jsonApi.CreateMemberShip(id);

            returnedMember = jsonApi.GetMemberById(id);

            Assert.AreEqual(50, returnedMember.LastLatitude);
            Assert.AreEqual(25, returnedMember.LastLongitude);
            Assert.IsNotNull(returnedMember.Membership);
        }
    }
}
