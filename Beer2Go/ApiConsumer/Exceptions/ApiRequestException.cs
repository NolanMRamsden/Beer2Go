using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsumer
{
    [Serializable]
    public class ApiRequestException : WebException
    {
        public ApiRequestException(HttpWebResponse response, WebException e) : base("",e,e == null ? WebExceptionStatus.UnknownError : e.Status,response)
        {

        }
    }
}
