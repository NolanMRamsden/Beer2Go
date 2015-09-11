using ApiConsumer.Requests;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsumer.Requesters
{
    public class JsonApiRequester : ApiRequester, IApiRequester
    {
        public override T Get<T>(IGetRequest request)
        {
            String strResult = base.Get(request);
            return JsonConvert.DeserializeObject<T>(strResult);
        }

        public override String Put<R>(IInsertRequest<R> request)
        {
            var webRequest = ApiRequestHelper.CreateRequest(request,"PUT");
            ApiRequestHelper.AttachJsonPayload<R>(webRequest, request);

            return ApiRequestHelper.MakeRequest(webRequest);
        }

        public override String Post<R>(IInsertRequest<R> request)
        {
            var webRequest = ApiRequestHelper.CreateRequest(request, "POST");
            ApiRequestHelper.AttachJsonPayload<R>(webRequest, request);

            return ApiRequestHelper.MakeRequest(webRequest);
        }
    }
}
