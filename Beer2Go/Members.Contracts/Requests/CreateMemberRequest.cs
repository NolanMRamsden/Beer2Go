using ApiConsumer.Requests;
using Members.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Members.Contracts.Requests
{
    public class CreateMemberRequest : BaseApiInsertRequest<MemberDto>
    {
        public CreateMemberRequest(String serviceUrl, MemberDto dto) : base(serviceUrl + "/api/Members", dto)
        {

        }

        protected override void ComposeArguments()
        {

        }
    }
}
