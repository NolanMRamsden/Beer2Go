using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleApi.Contracts.Models
{
    [Serializable]
    public class GeocodedWaypoint
    {
        public DirectionsResponseStatus geocoder_status { get; set; }
        public string place_id { get; set; }
        public List<string> types { get; set; }
    }
}
