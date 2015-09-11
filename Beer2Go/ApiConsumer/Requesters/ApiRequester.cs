using ApiConsumer.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsumer.Requesters
{
    public abstract class ApiRequester : IApiRequester
    {
        public String Delete(IDeleteRequest request)
        {
            return CreateAndSubmitRequest(request, "DELETE");
        }

        protected String Get(IGetRequest request)
        {
            return CreateAndSubmitRequest(request, "GET");
        }

        private String CreateAndSubmitRequest(IApiRequest request, String method)
        {
            var webRequest = ApiRequestHelper.CreateRequest(request, method);
            return ApiRequestHelper.MakeRequest(webRequest);
        }

        public abstract T Get<T>(IGetRequest request);
        public abstract String Put<R>(IInsertRequest<R> request);
        public abstract String Post<R>(IInsertRequest<R> request);
    }
}
