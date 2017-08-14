using NetCore.GoogleMapsApi.Entity;

namespace NetCore.GoogleMapsApi.Interfaces
{
    public interface IGoogleMapsGeoLocation
    {
        GoogleMapsServiceResponse<RootObject> Geocoding(string address);
        GoogleMapsServiceResponse<RootObject> Geocoding(string latitude, string longitude);
    }
}