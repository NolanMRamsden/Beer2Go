using ApiConsumer.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Contracts.Requests
{
    public class DeleteProductRequest : BaseApiRequest
    {
        public int? ProductId { get; set; }

        public DeleteProductRequest(String serviceBase) : base(serviceBase + "/api/Products")
        {
        }

        protected override void ComposeArguments()
        {
            if (ProductId.HasValue)
            {
                AppendPair("productId", ProductId.Value.ToString());
            }
        }
    }
}
