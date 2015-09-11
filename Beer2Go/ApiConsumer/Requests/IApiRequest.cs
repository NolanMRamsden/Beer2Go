using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsumer.Requests
{
    public interface IApiRequest
    {
        String BaseUrl { get; }
        String Url { get; }
    }
}
