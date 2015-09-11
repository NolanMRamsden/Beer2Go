using GoogleApi.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Location.Data.Storage
{
    public interface ITruckLocationStorage
    {
        IEnumerable<GeoLocation> GetAllTruckLocations();
        GeoLocation GetLocation(int truckId);
        void LogLocation(int truckId, GeoLocation location);
    }
}
