using NetCore.GoogleMapsApi.Entity;
using NetCore.GoogleMapsApi.Enums;
using NetCore.GoogleMapsApi.Implementations;
using NetCore.GoogleMapsApi.Interfaces;
using Newtonsoft.Json;
using System;
using System.Net.Http;

namespace NetCore.GoogleMapsApi
{
    internal class GoogleMapsDistanceMatrix : ServiceBase, IGoogleMapsDistanceMatrix
    {
        private const string UrlGeocoding = "/distancematrix";

        public GoogleMapsDistanceMatrix(GoogleMapsApiSettings settings)
            :base(settings)
        {

        }

        public GoogleMapsServiceResponse<RootObjectDistanceMatrix> GetDistance(string origin, string destination, string mode)
        {
            GoogleMapsServiceResponse<RootObjectDistanceMatrix> response = new GoogleMapsServiceResponse<RootObjectDistanceMatrix>();
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string urlRequest = _settings.UrlRootApi + UrlGeocoding + string.Format("/json?units=metric&origins={0}&destinations={1}&key={2}", origin, destination, _settings.ApiKey);
                    if (!String.IsNullOrEmpty(mode))
                        urlRequest += "&mode=" + mode;

                    var stringTask = client.GetStringAsync(urlRequest);
                    string result = stringTask.Result;
                    RootObjectDistanceMatrix resultCall = JsonConvert.DeserializeObject<RootObjectDistanceMatrix>(result);
                    response.Result = resultCall;
                    response.Status = base.GetEnumStatus(resultCall);
                }
            }
            catch (Exception ex)
            {
                response.Exception = ex;
                if (ex.InnerException.GetType() == typeof(HttpRequestException))
                    response.Status = Enums.GoogleMapsResponseStatus.BAD_REQUEST_ERROR;
                else
                    response.Status = Enums.GoogleMapsResponseStatus.UNKNOWN_ERROR;
            }
            return response;
        }
    }
}
