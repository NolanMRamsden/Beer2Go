using GoogleApi.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Location.Contracts.Models
{
    public class DeliveryPriceDto
    {
        public GeoLocation ClosestTruck { get; set; }
        public int Kilometres { get; set; }
        public decimal Cost { get; set; }
    }
}
