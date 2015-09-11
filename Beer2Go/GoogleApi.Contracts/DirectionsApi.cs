using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;
using GoogleApi.Contracts.Models;
using ApiConsumer;
using ApiConsumer.Requesters;

namespace GoogleApi.Contracts
{
    public class DirectionsApi
    {
        private IApiRequester requester { get; set; }

        public DirectionsApi(IApiRequester apiRequester)
        {
            requester = apiRequester;
        }

        public DirectionsResponse GetDirections(GetDirectionsRequest request)
        {
            return requester.Get<DirectionsResponse>(request);
        }
    }
}
