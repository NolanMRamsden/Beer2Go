using Members.Data.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Members.Service.Controllers
{
    public class MemberShipController : ApiController
    {
        private readonly IMemberData memberData;

        public MemberShipController(IMemberData data)
        {
            memberData = data;
        }

        [HttpPut]
        [Route("api/MemberShips")]
        public void Put([FromUri]int memberId)
        {
            memberData.CreateMemberShip(memberId);
        }
    }
}
