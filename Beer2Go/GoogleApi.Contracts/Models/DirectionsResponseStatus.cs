using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleApi.Contracts.Models
{
    [Serializable]
    public enum DirectionsResponseStatus
    {
        OK, NOT_FOUND, ZERO_RESULTS, MAX_WAYPOINTS_EXCEEDED, INVALID_REQUEST, OVER_QUERY_LIMIT, REQUEST_DENIED, UNKNOWN_ERROR
    }
}
