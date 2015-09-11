using ApiConsumer.Requests;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ApiConsumer.Requesters
{
    public class XmlRequester : ApiRequester, IApiRequester
    {
        public override T Get<T>(IGetRequest request)
        {
            var webRequest = ApiRequestHelper.CreateRequest(request, "GET"); 
            String strResult = ApiRequestHelper.MakeRequest(webRequest);

            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (StringReader reader = new StringReader(strResult))
            {
                return (T)serializer.Deserialize(reader);
            }
        }

        public override String Put<R>(IInsertRequest<R> request)
        {
            var webRequest = ApiRequestHelper.CreateRequest(request,"PUT");
            ApiRequestHelper.AttachXmlPayload<R>(webRequest, request);

            return ApiRequestHelper.MakeRequest(webRequest);
        }

        public override String Post<R>(IInsertRequest<R> request)
        {
            var webRequest = ApiRequestHelper.CreateRequest(request, "POST");
            ApiRequestHelper.AttachXmlPayload<R>(webRequest, request);

            return ApiRequestHelper.MakeRequest(webRequest);
        }
    }
}
