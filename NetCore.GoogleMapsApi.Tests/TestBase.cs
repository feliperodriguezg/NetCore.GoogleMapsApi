using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace NetCore.GoogleMapsApi.Tests
{
    public abstract class TestBase
    {
        protected GoogleMapsApiService _services;

        [TestInitialize]
        public void Init()
        {
            _services = new GoogleMapsApiService(new GoogleMapsApiSettings(ReadApiKey()));
        }

        private static string ReadApiKey()
        {
            return File.ReadAllText("googlemaps_api_key.txt").Trim();
        }

        private void CheckStatus(RootObject response, string status)
        {
            Assert.IsNotNull(response);
            Assert.IsTrue(!String.IsNullOrEmpty(response.status));
            Assert.IsTrue(response.status == status, "status: " + response.status);

        }

        protected virtual void StatusRequestDenied(RootObject response)
        {
            CheckStatus(response, "REQUEST_DENIED");
        }

        protected virtual void StatusZeroResults(RootObject response)
        {
            CheckStatus(response, "ZERO_RESULTS");
        }

        protected virtual void StatusOk(RootObject response)
        {
            CheckStatus(response, "OK");
        }
    }
}
