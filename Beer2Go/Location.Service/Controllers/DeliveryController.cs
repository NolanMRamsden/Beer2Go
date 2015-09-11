using GoogleApi.Contracts.Models;
using Location.Contracts.Models;
using Location.Data.Storage;
using Location.Service.Business;
using Service.Common.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Location.Service.Controllers
{
    public class DeliveryController : ApiController
    {
        ITruckLocationStorage truckStorage;

        public DeliveryController(ITruckLocationStorage storage)
        {
            this.truckStorage = storage;
        }

        [HttpGet]
        [RestrictDomains("DeliveryGetDomains")]
        [Route("api/Delivery")]
        public DeliveryPriceDto Get([FromUri]decimal lat, [FromUri]decimal lng)
        {
            var location = new GeoLocation(lat, lng);
            var trucks = truckStorage.GetAllTruckLocations();
            //var closestTruck = trucks.OrderByDescending(t => location.DistanceTo(t)).First();
            var closestTruck = new GeoLocation(49.1384125m,-123.16684400000001m);
            var distance = closestTruck.DistanceTo(location);
            var costForDelivery = DeliveryPricing.CostForDelivery(distance);

            return new DeliveryPriceDto()
            {
                ClosestTruck = closestTruck,
                Kilometres = (int)(distance + 0.5),
                Cost = costForDelivery
            };
        }
    }
}
