using ApiConsumer.Requesters;
using Members.Contracts.Models;
using Members.Contracts.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Members.Contracts
{
    public class MemberApi : IMemberApi
    {
        String baseUrl { get; set; }
        IApiRequester requester { get; set; }

        public MemberApi(String baseUrl, IApiRequester requester)
        {
            this.baseUrl = baseUrl;
            this.requester = requester;
        }

        public MemberDto GetMemberById(int memberId)
        {
            var request = new GetMemberRequest(baseUrl) { MemberId = memberId };
            return requester.Get<MemberDto>(request);
        }

        public int StoreMember(MemberDto member)
        {
            var request = new CreateMemberRequest(baseUrl, member);
            String response = requester.Put<MemberDto>(request);

            return Convert.ToInt32(response);
        }

        public void CreateMemberShip(int memberId)
        {
            var request = new CreateMemberShipRequest(baseUrl, memberId);
            requester.Put(request);
        }

        public void SetMemberLocation(int memberId, decimal latitude, decimal longitude)
        {
            var request = new SetMemberLocationRequest(baseUrl, memberId, latitude, longitude);
            requester.Put(request);
        }
    }
}
