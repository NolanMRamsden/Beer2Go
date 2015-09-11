using ApiConsumer.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsumer.Requesters
{
    public interface IApiRequester
    {
        T Get<T>(IGetRequest request);
        String Delete(IDeleteRequest request);
        String Put<R>(IInsertRequest<R> request);
        String Post<R>(IInsertRequest<R> request);
    }
}
