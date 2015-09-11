using GoogleApi.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Location.Data.Storage.RunTimeStorage
{
    public class RunTimeTruckStorage : ITruckLocationStorage
    {
        private Dictionary<int, GeoLocation> runtimeStorage;

        public RunTimeTruckStorage()
        {
            runtimeStorage = new Dictionary<int, GeoLocation>();
        }

        public IEnumerable<GeoLocation> GetAllTruckLocations()
        {
            return runtimeStorage.Values;
        }

        public GeoLocation GetLocation(int truckId)
        {
            if (runtimeStorage.ContainsKey(truckId))
                return runtimeStorage[truckId];

            return null;
        }

        public void LogLocation(int truckId, GeoLocation location)
        {
            if (runtimeStorage.ContainsKey(truckId))
                runtimeStorage[truckId] = location;
            else
                runtimeStorage.Add(truckId, location);
        }
    }
}
