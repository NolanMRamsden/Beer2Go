using ApiConsumer;
using ApiConsumer.Requests;
using GoogleApi.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleApi.Contracts
{
    public class GetDirectionsRequest : BaseApiRequest
    {
        public const String baseUrl = @"https://maps.googleapis.com/maps/api/directions/";
        public Boolean Optimize = true;

        public GeoLocation Origin { get; set; }
        public GeoLocation Destination { get; set; }
        public IList<GeoLocation> Waypoints { get; set; } 

        public GetDirectionsRequest(String type) : base(baseUrl + type)
        {
            Waypoints = new List<GeoLocation>();
        }

        public GetDirectionsRequest() : base(baseUrl + "json")
        {
            Waypoints = new List<GeoLocation>();
        }

        protected override void ComposeArguments()
        {
            if (Origin != null) AppendPair("origin",Origin.ToString());
            if (Destination != null) AppendPair("destination", Destination.ToString());
            
            if (Waypoints.Count() == 0) return;
            String waypointsArgument = "optimize:" + Optimize.ToString().ToLower() + "|";
            waypointsArgument += Waypoints.First().ToString();
            for(int i=1; i < Waypoints.Count; i++)
                waypointsArgument += "|" + Waypoints[i].ToString();

            AppendPair("waypoints",waypointsArgument);
        }
    }
}
