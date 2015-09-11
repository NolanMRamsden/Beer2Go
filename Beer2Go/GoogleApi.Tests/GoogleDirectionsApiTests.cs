using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoogleApi.Contracts.Models;
using GoogleApi.Contracts;
using ApiConsumer.Requesters;

namespace GoogleApi.Tests
{
    [TestClass]
    public class GoogleDirectionsApiTests
    {
        GetDirectionsRequest request;
        DirectionsApi jsonRequester;
        DirectionsApi xmlRequester;

        [TestInitialize]
        public virtual void DirectionsApiInitialize() 
        {
            request = new GetDirectionsRequest();
            jsonRequester = new DirectionsApi(new JsonApiRequester());
            xmlRequester = new DirectionsApi(new JsonApiRequester());
        }

        [TestMethod]
        public void TwoPointRequest()
        {
            request.Origin = new GeoLocation(49.272686099999987m, -123.1338566m);
            request.Destination = new GeoLocation("Granville Island,BC");

            var response = jsonRequester.GetDirections(request);

            Assert.AreEqual(DirectionsResponseStatus.OK, response.status);
            Assert.IsTrue(response.routes.Count > 0);
            Assert.AreEqual(2, response.geocoded_waypoints.Count);
            foreach (var geocode in response.geocoded_waypoints)
                Assert.AreEqual(DirectionsResponseStatus.OK, geocode.geocoder_status);
        }

        [TestMethod]
        public void MultipleWaypoints()
        {
            request.Origin = new GeoLocation(49.272686099999987m, -123.1338566m);
            request.Destination = new GeoLocation("Granville Island,BC");
            request.Waypoints.Add(new GeoLocation("Burnett School,Richmond,BC"));
            request.Waypoints.Add(new GeoLocation("YVR Airport,Richmond,BC"));
            request.Optimize = false;

            var response = jsonRequester.GetDirections(request);

            Assert.AreEqual(DirectionsResponseStatus.OK, response.status);
            Assert.AreEqual(4, response.geocoded_waypoints.Count);
            foreach (var geocode in response.geocoded_waypoints)
                Assert.AreEqual(DirectionsResponseStatus.OK, geocode.geocoder_status);
            Assert.IsTrue(response.routes.Count > 0);
            foreach (var route in response.routes)
                Assert.AreEqual(3, route.legs.Count);
            Route firstRoute = response.routes.First();
            Assert.AreEqual(2, firstRoute.waypoint_order.Count);
            Assert.AreEqual(0, firstRoute.waypoint_order[0]);
            Assert.AreEqual(1, firstRoute.waypoint_order[1]);
        }

        [TestMethod]
        public void RouteIsRearrangedWhenOptimizeIsOn()
        {
            if (!request.Optimize) request.Optimize = true;

            request.Origin = new GeoLocation(49.272686099999987m, -123.1338566m); //5180 hollyfield
            request.Destination = new GeoLocation("Seattle,US");
            request.Waypoints.Add(new GeoLocation("Portland,Oregon"));
            request.Waypoints.Add(new GeoLocation("Burnett School,Richmond,BC"));

            var responseOptimize = jsonRequester.GetDirections(request);

            Assert.AreEqual(DirectionsResponseStatus.OK, responseOptimize.status);
            Assert.AreEqual(4, responseOptimize.geocoded_waypoints.Count);
            foreach (var geocode in responseOptimize.geocoded_waypoints)
                Assert.AreEqual(DirectionsResponseStatus.OK, geocode.geocoder_status);
            Assert.IsTrue(responseOptimize.routes.Count > 0);
            foreach (var route in responseOptimize.routes)
                Assert.AreEqual(3, route.legs.Count);
            Route firstRoute = responseOptimize.routes.First();

            Assert.AreEqual(2, firstRoute.waypoint_order.Count);
            Assert.AreEqual(1, firstRoute.waypoint_order[0]);
            Assert.AreEqual(0, firstRoute.waypoint_order[1]);
        }

        [TestMethod]
        public void XmlMatchesJson()
        {
            request.Origin = new GeoLocation(49.272686099999987m, -123.1338566m); //5180 hollyfield
            request.Destination = new GeoLocation("Seattle,US");
            request.Waypoints.Add(new GeoLocation("Portland,Oregon"));
            request.Waypoints.Add(new GeoLocation("Burnett School,Richmond,BC"));
        }

        [TestCleanup]
        public void DirectionsApiCleanup()
        {
            request.Origin = new GeoLocation(49.272686099999987m, -123.1338566m); //5180 hollyfield
            request.Destination = new GeoLocation("Seattle,US");
            request.Waypoints.Add(new GeoLocation("Portland,Oregon"));
            request.Waypoints.Add(new GeoLocation("Burnett School,Richmond,BC"));

            var json = jsonRequester.GetDirections(request);
            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1)); //Api request limit
            var xml = xmlRequester.GetDirections(request);

            Assert.AreEqual(xml.status, json.status);
            Assert.AreEqual(xml.geocoded_waypoints.Count, json.geocoded_waypoints.Count);
            Assert.AreEqual(xml.routes.Count, json.routes.Count);
        }     
    }
}
