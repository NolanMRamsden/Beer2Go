using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsumer.Requests
{
    public abstract class BaseApiInsertRequest<T> : BaseApiRequest, IInsertRequest<T>
    {
        public BaseApiInsertRequest(String urlBase, T data) : base(urlBase)
        {
            Data = data;
        }

        public BaseApiInsertRequest(String urlBase) : base(urlBase)
        {

        }

        public T Data { get; set; }
    }
}
