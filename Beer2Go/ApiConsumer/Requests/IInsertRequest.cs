using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsumer.Requests
{
    public interface IInsertRequest<T> : IApiRequest
    {
        T Data { get; set; }
    }
}
