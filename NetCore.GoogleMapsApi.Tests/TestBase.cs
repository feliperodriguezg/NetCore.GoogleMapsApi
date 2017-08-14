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
    }
}
