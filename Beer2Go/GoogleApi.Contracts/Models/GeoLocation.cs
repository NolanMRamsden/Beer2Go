using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleApi.Contracts.Models
{
    [Serializable]
    public class GeoLocation
    {
        public String Place { get; set; }
        public Decimal? Latitude { get; set; }
        public Decimal? Longitude { get; set; }

        public GeoLocation(String place)
        {
            Place = place;
        }

        public GeoLocation(Decimal latitude, Decimal longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public double DistanceTo(GeoLocation location)
        {
            return this.ToCoordinate().GetDistanceTo(location.ToCoordinate());
        }

        public GeoCoordinate ToCoordinate()
        {
            return new GeoCoordinate((double)Latitude, (double)Longitude);
        }

        public override string ToString()
        {
            if (Latitude == null || Longitude == null)
                return Place;
            else
                return Latitude + "," + Longitude;
        }
    }
}
