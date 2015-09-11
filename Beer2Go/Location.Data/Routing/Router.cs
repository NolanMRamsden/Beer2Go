using Location.Data.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Orders.Contracts;
using System.Threading.Tasks;
using Orders.Contracts.Models;
using Orders.Contracts.Requests;
using Location.Data.References;
using GoogleApi.Contracts.Models;
using GoogleApi.Contracts;

namespace Location.Data.Routing
{
    internal class Router
    {
        public ITruckLocationStorage trucks { get; set; }
        public IServiceReferences references { get; set; }
        public IOrdersApi orders { get; set; }

        internal Router(ITruckLocationStorage truckStorage, IOrdersApi ordersDataApi, IServiceReferences services)
        {
            trucks = truckStorage;
            orders = ordersDataApi;
            references = services;
        }

        public DirectionsResponse GetRoute(int truckId)
        {
            throw new NotImplementedException();
        }

        protected GeoLocation GetLocation(OrderDto order)
        {
            return new GeoLocation(order.Latitude, order.Longitude);
        }

        protected List<OrderDto> GetTopNOrders(int n)
        {
            var allActiveOrders = orders.GetActiveOrders().OrderByDescending(x => x.SubmittedAt);

            return allActiveOrders.Take(n).ToList();
        }
    }
}
