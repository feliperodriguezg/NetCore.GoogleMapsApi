namespace NetCore.GoogleMapsApi.Interfaces
{
    public interface IGoogleMapsGeoLocation
    {
        RootObject Geocoding(string address);
        RootObject Geocoding(string latitude, string longitude);
    }
}