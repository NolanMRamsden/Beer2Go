using ApiConsumer.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Orders.Contracts.Requests
{
    public class DeleteOrderRequest : BaseApiRequest
    {
        public int? OrderId { get; set; }

        public DeleteOrderRequest(String serviceBase) : base(serviceBase+"/api/Orders")
        {
        }

        protected override void ComposeArguments()
        {
            if (OrderId.HasValue)
            {
                AppendPair("orderId", OrderId.Value.ToString());
            }
        }
    }
}
