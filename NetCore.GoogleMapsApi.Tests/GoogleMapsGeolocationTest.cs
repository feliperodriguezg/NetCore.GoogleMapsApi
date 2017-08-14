using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using NetCore.GoogleMapsApi.Entity;
using NetCore.GoogleMapsApi.Enums;

namespace NetCore.GoogleMapsApi.Tests
{
    [TestClass]
    public class GoogleMapsGeolocationTest: TestBase
    {
        const string Latitude = "40.758895";
        const string Longitude = "-73.9873197";

        private void BasicTestResponse(GoogleMapsServiceResponse<RootObject> response, GoogleMapsResponseStatus status)
        {
            Assert.IsNotNull(response, "response is null");
            Assert.IsTrue(response.Status == status, "status is null");
            if (status == GoogleMapsResponseStatus.OK)
                Assert.IsNull(response.Exception);
            else if(status == GoogleMapsResponseStatus.BAD_REQUEST_ERROR)
                Assert.IsNotNull(response.Exception);
        }

        private RootObject Geocoding(string address, GoogleMapsResponseStatus status)
        {
            var response = _services.GeoLocation.Geocoding(address);
            BasicTestResponse(response, status);
            return response.Result;
        }

        private RootObject Geocoding(string latitude, string longitude, GoogleMapsResponseStatus status)
        {
            var response = _services.GeoLocation.Geocoding(latitude, longitude);
            BasicTestResponse(response, status);
            return response.Result;
        }

        [TestMethod]
        public void Geocoding_ByAddress()
        {
            var response = Geocoding("Manhattan, Nueva York 10036, EE. UU.", GoogleMapsResponseStatus.OK);
            Assert.IsTrue(response.results.Count > 0, "Results is empty or null");
        }

        [TestMethod]
        public void Geocoding_ApiKey_Access_Denied()
        {
            _services = new GoogleMapsApiService(new GoogleMapsApiSettings("apiinvalid_324324234324324"));
            var response = Geocoding("Manhattan, Nueva York 10036, EE. UU.", GoogleMapsResponseStatus.REQUEST_DENIED);
        }

        [TestMethod]
        public void Geocoding_ByAddress_False_Address()
        {
            var response = Geocoding("MeloInventoT�, Marth", GoogleMapsResponseStatus.ZERO_RESULTS);
        }

        [TestMethod]
        public void Geocoding_ByCoordinates()
        {
            var response = Geocoding(Latitude, Longitude, GoogleMapsResponseStatus.OK);
            Assert.IsTrue(response.results.Count > 0, "Results is empty or null");
        }

        [TestMethod]
        public void Geocoding_ByCoordinates_False_Coordinates()
        {
            var response = Geocoding("0.00223232", "-1.23233344445", GoogleMapsResponseStatus.ZERO_RESULTS);
        }

        [TestMethod]
        public void Geocoding_ByCoordinates_Empty_Or_Null()
        {
            var response = Geocoding("", "", GoogleMapsResponseStatus.BAD_REQUEST_ERROR);
            response = Geocoding(null, null, GoogleMapsResponseStatus.BAD_REQUEST_ERROR);
        }
    }
}