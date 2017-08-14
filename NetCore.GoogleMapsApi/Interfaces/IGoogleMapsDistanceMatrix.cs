using NetCore.GoogleMapsApi.Entity;

namespace NetCore.GoogleMapsApi.Interfaces
{
    public interface IGoogleMapsDistanceMatrix
    {
        GoogleMapsServiceResponse<RootObjectDistanceMatrix> GetDistance(string origin, string destination, string mode);
    }
}