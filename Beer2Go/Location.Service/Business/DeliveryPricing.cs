using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Location.Service.Business
{
    public class DeliveryPricing
    {
        public static decimal CostForDelivery(double distanceInKm)
        {
            if (distanceInKm < 10)
                return 10;
            if (distanceInKm < 20)
                return 15;
            if (distanceInKm < 35)
                return 20;
            return 100;
        }
    }
}