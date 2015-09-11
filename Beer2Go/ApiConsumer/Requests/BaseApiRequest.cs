using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsumer.Requests
{
    public abstract class BaseApiRequest : IDeleteRequest, IGetRequest
    {
        private readonly string _baseUrl;
        public string BaseUrl { get { return _baseUrl; } }

        public string Url
        {
            get { return GetUrl(); }
        }

        protected String composingUrl;

        public BaseApiRequest(String urlBase)
        {
            _baseUrl = urlBase;
        }

        protected virtual String GetUrl()
        {
            first = true;
            composingUrl = BaseUrl;
            ComposeArguments();
            return composingUrl;
        }

        protected abstract void ComposeArguments();

        private Boolean first = true;
        protected void AppendPair(String key, String value)
        {
            if (first && !composingUrl.Contains("?"))
            {
                composingUrl += "?";
            }else
            {
                composingUrl += "&";
            }
            first = false;
            composingUrl += key + "=" + value.Replace(" ", "+");
        }
    }
}
