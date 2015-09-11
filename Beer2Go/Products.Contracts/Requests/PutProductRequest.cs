using ApiConsumer.Requests;
using Products.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Contracts.Requests
{
    public class PutProductRequest : BaseApiInsertRequest<ProductDto>
    {
        public PutProductRequest(String serviceUrl, ProductDto dto) : base(serviceUrl + "/api/Products", dto)
        {

        }

        protected override void ComposeArguments()
        {

        }
    }
}
