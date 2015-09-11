using Members.Contracts.Models;
using Members.Data.Storage;
using Members.Service.DataBoundary;
using Service.Common.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Members.Service.Controllers
{
    public class MemberController : ApiController
    {
        private readonly IMemberData memberData;

        public MemberController(IMemberData data)
        {
            memberData = data;
        }

        [HttpGet]
        [Route("api/Members")]
        public MemberDto Get([FromUri]int memberId)
        {
            var member = memberData.GetMemberById(memberId);
            var dto = MemberComposer.DtoFromMember(member);

            return dto;
        }

        [HttpPut]
        [ValidateModel]
        [Route("api/Members")]
        public int Put([FromBody]MemberDto member)
        {
            var m = MemberComposer.MemberFromDto(member);
            
            return memberData.StoreMember(m);
        }

        [HttpPut]
        [ValidateModel]
        [Route("api/Members")]
        public void Put([FromUri]int memberId, [FromUri]decimal latitude,[FromUri]decimal longitude)
        {
            memberData.SetMemberLocation(memberId, latitude, longitude);
        }
    }
}
