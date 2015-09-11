using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Location.Data.References
{
    public interface IServiceReferences
    {
        String OrdersServiceUrl { get; }
        String GoogleDirectionsApi { get; }
    }
}
