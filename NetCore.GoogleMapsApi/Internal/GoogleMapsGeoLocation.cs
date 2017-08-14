using NetCore.GoogleMapsApi.Entity;
using NetCore.GoogleMapsApi.Implementations;
using NetCore.GoogleMapsApi.Interfaces;
using Newtonsoft.Json;
using System;
using System.Net.Http;

namespace NetCore.GoogleMapsApi
{
    internal class GoogleMapsGeoLocation : ServiceBase, IGoogleMapsGeoLocation
    {
        private const string UrlGeocoding = "/geocode";

        public GoogleMapsGeoLocation(GoogleMapsApiSettings settings)
            :base(settings)
        {

        }

        public GoogleMapsServiceResponse<RootObject> Geocoding(string latitude, string longitude)
        {
            return ProccessGeocodingAsync(latitude, longitude);
        }

        public GoogleMapsServiceResponse<RootObject> Geocoding(string address)
        {
            return ProcessAddress(address);
        }

        private GoogleMapsServiceResponse<RootObject> ProccessGeocodingAsync(string latitude, string longitude)
        {
            GoogleMapsServiceResponse<RootObject> response = new GoogleMapsServiceResponse<RootObject>();
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string urlRequest = _settings.UrlRootApi + UrlGeocoding + string.Format("/json?latlng={0},{1}&key={2}", latitude, longitude, _settings.ApiKey);
                    var stringTask = client.GetStringAsync(urlRequest);
                    string result = stringTask.Result;
                    RootObject responseCall = JsonConvert.DeserializeObject<RootObject>(result);
                    response.Result = responseCall;
                    response.Status = base.GetEnumStatus(responseCall);
                }
                catch(Exception ex)
                {
                    response.Exception = ex;
                    if (ex.InnerException.GetType() == typeof(HttpRequestException))
                        response.Status = Enums.GoogleMapsResponseStatus.BAD_REQUEST_ERROR;
                    else
                        response.Status = Enums.GoogleMapsResponseStatus.UNKNOWN_ERROR;
                }
            }
            return response;
        }

        private GoogleMapsServiceResponse<RootObject> ProcessAddress(string address)
        {
            GoogleMapsServiceResponse<RootObject> response = new GoogleMapsServiceResponse<RootObject>();
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string urlRequest = _settings.UrlRootApi + UrlGeocoding + string.Format("/json?address={0}&key={1}", address, _settings.ApiKey);
                    var stringTask = client.GetStringAsync(urlRequest);
                    string result = stringTask.Result;
                    RootObject responseCall = JsonConvert.DeserializeObject<RootObject>(result);
                    response.Result = responseCall;
                    response.Status = base.GetEnumStatus(responseCall);
                }
                catch (Exception ex)
                {
                    response.Exception = ex;
                    if (ex.InnerException.GetType() == typeof(HttpRequestException))
                        response.Status = Enums.GoogleMapsResponseStatus.BAD_REQUEST_ERROR;
                    else
                        response.Status = Enums.GoogleMapsResponseStatus.UNKNOWN_ERROR;
                }
            }
            return response;
        }

    }
}
