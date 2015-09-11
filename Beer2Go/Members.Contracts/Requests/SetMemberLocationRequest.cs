using ApiConsumer.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Members.Contracts.Requests
{
    public class SetMemberLocationRequest : BaseApiInsertRequest<int>
    {
        public int MemberId { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }

        public SetMemberLocationRequest(String baseUrl, int memberId, decimal latitude, decimal longitude)
            : base(baseUrl + "/api/Members", 0)
        {
            MemberId = memberId;
            Latitude = latitude;
            Longitude = longitude;
        }

        protected override void ComposeArguments()
        {
            AppendPair("memberId", MemberId.ToString());
            AppendPair("latitude", Latitude.ToString());
            AppendPair("longitude", Longitude.ToString());
        }
    }
}
