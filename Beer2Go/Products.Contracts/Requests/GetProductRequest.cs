using ApiConsumer.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Contracts.Requests
{
    public class GetProductRequest : BaseApiRequest
    {
        public int? ProductId { get; set; }

        public GetProductRequest(String serviceUrl) : base(serviceUrl + "/api/Products")
        {

        }

        protected override void ComposeArguments()
        {
            if (ProductId.HasValue)
            {
                AppendPair("productId", ProductId.ToString());
            }
        }
    }
}
