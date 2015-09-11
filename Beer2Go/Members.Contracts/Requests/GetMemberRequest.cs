using ApiConsumer.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Members.Contracts.Requests
{
    public class GetMemberRequest : BaseApiRequest
    {
        public int? MemberId { get; set; }

        public GetMemberRequest(String baseUrl) : base(baseUrl + "/api/Members")
        {

        }

        protected override void ComposeArguments()
        {
            if (MemberId.HasValue)
            {
                AppendPair("memberId", MemberId.ToString());
            }
        }
    }
}
