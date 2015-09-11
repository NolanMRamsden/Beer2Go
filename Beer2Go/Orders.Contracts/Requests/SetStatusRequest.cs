using ApiConsumer.Requests;
using Orders.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Contracts.Requests
{
    public class SetStatusRequest : BaseApiInsertRequest<OrderStatus>
    {
        public int OrderId { get; set; }

        public SetStatusRequest(String serviceUrl, int orderId, OrderStatus status) : base(serviceUrl + "/api/OrderManagement", status)
        {
            OrderId = orderId;
        }

        protected override void ComposeArguments()
        {
            AppendPair("orderId", OrderId.ToString());
        }
    }
}
