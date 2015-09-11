using ApiConsumer.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Members.Contracts.Requests
{
    class CreateMemberShipRequest : BaseApiInsertRequest<int>
    {
        public int MemberId;

        public CreateMemberShipRequest(String baseUrl, int memberId)
            : base(baseUrl + "/api/Memberships", 0)
        {
            MemberId = memberId;
        }

        protected override void ComposeArguments()
        {
            AppendPair("memberId", MemberId.ToString());
        }
    }
}
