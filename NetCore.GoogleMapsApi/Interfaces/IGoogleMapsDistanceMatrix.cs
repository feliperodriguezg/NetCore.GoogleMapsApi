namespace NetCore.GoogleMapsApi.Interfaces
{
    public interface IGoogleMapsDistanceMatrix
    {
        RootObjectDistanceMatrix GetDistance(string origin, string destination, string mode);
    }
}