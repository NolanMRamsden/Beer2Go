using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GoogleApi.Contracts.Models;
using GoogleApi.Contracts;
using ApiConsumer;
using ApiConsumer.Requests;

namespace Location.Tests.ApiTests
{
    [TestClass]
    public class UrlComposingTests
    {
        List<GeoLocation> testLocations = new List<GeoLocation>();

        [TestInitialize]
        public void UrlComposingInitialize() 
        {
            testLocations.Add(new GeoLocation("123 Fake Street"));
            testLocations.Add(new GeoLocation(1.23m, 64.22333m));
            testLocations.Add(new GeoLocation("456 Not Real Street"));
            testLocations.Add(new GeoLocation("123 Diagon Alley"));

        }

        [TestMethod]
        public void UrlWithNoArguments()
        {
            String urlBase = GetDirectionsRequest.baseUrl;
            BaseApiRequest request = new GetDirectionsRequest();
            BaseApiRequest requestXml = new GetDirectionsRequest("xml");
            String result = request.Url;
            String resultXml = requestXml.Url;

            Assert.AreEqual(urlBase +  "json", result);
            Assert.AreEqual(urlBase + "xml", resultXml);
            Assert.IsFalse(result.Contains("?"), "? Test Failed");
            Assert.IsFalse(result.Contains("&"), "& Test Failed");
        }

        [TestMethod]
        public void UrlWithOneArgument()
        {
            BaseApiRequest request = new GetDirectionsRequest()
            {
                Origin = testLocations[0],
            };
            String result = request.Url;

            Assert.IsTrue(result.Contains("?"), "? Test Failed");
            Assert.IsFalse(result.Contains("&"), "& Test Failed");
        }

        [TestMethod]
        public void UrlWithMultipleArguments()
        {
            BaseApiRequest request = new GetDirectionsRequest()
            {
                Origin = testLocations[0],
                Destination = testLocations[1]
            };
            String result = request.Url;

            Assert.IsTrue(result.Contains("?"), "? Test Failed");
            Assert.IsTrue(result.Contains("&"), "& Test Failed");
        }

        [TestCleanup]
        public void UrlComposingCleanup() { }     
    }
}
