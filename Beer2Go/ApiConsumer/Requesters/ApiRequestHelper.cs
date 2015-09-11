using ApiConsumer.Requests;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ApiConsumer.Requesters
{
    internal static class ApiRequestHelper
    {
        internal static HttpWebRequest CreateRequest(IApiRequest request, String method)
        {
            HttpWebRequest webRequest = WebRequest.Create(request.Url) as HttpWebRequest;
            webRequest.Method = method;
            return webRequest;
        }

        internal static void AttachJsonPayload<T>(HttpWebRequest webRequest, IInsertRequest<T> request)
        {
            webRequest.ContentType = "text/json";
            String json = JsonConvert.SerializeObject(request.Data);
            AttachPayload(webRequest, json);
        }

        internal static void AttachXmlPayload<T>(HttpWebRequest webRequest, IInsertRequest<T> request)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            webRequest.ContentType = "application/xml";
            using (var streamWriter = new StreamWriter(webRequest.GetRequestStream()))
            {
                serializer.Serialize(streamWriter, request.Data);
                streamWriter.Flush();
            }
        }

        internal static void AttachPayload(HttpWebRequest webRequest, String payload)
        {
            using (var streamWriter = new StreamWriter(webRequest.GetRequestStream()))
            {
                streamWriter.Write(payload);
                streamWriter.Flush();
            }
        }

        internal static String MakeRequest(HttpWebRequest webRequest)
        {
            using (HttpWebResponse response = webRequest.GetResponse() as HttpWebResponse)
            {
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    using (var stream = new StreamReader(response.GetResponseStream()))
                    {
                        return stream.ReadToEnd();
                    }
                }else if (response.StatusCode == HttpStatusCode.NoContent)
                {
                    return String.Empty;
                }
                else
                {
                    throw new ApiRequestException(response, null);
                }
            }
        }
    }
}
