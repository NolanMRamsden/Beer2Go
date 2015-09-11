using ApiConsumer.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Contracts.Requests
{
    class SetInventoryRequest : BaseApiInsertRequest<int>
    {
        int productId;

        public SetInventoryRequest(String serviceUrl, int productId, int inventory) : base(serviceUrl + "/api/Inventory", inventory)
        {
            this.productId = productId;
        }

        protected override void ComposeArguments()
        {
            AppendPair("productId", productId.ToString());
        }
    }
}
