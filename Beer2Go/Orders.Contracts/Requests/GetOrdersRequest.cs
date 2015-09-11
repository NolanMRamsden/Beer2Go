using Orders.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiConsumer;
using ApiConsumer.Requests;

namespace Orders.Contracts.Requests
{
    public class GetOrdersRequest : BaseApiRequest
    {
        public int? OrderId { get; set; }

        public GetOrdersRequest(String serviceUrl) : base(serviceUrl + "/api/Orders")
        {

        }

        protected override void ComposeArguments()
        {
            if (OrderId.HasValue)
            {
                AppendPair("OrderId", OrderId.ToString());
            }
        }
    }
}
