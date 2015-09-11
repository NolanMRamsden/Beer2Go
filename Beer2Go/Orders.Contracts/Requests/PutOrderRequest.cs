using ApiConsumer;
using ApiConsumer.Requests;
using Orders.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Orders.Contracts.Requests
{
    public class PutOrderRequest : BaseApiInsertRequest<OrderDto>
    {
        public PutOrderRequest(String serviceUrl, OrderDto dto) : base(serviceUrl + "/api/Orders", dto)
        {

        }

        protected override void ComposeArguments()
        {

        }
    }
}
