namespace NetCore.GoogleMapsApi
{
    public sealed class GoogleMapsApiSettings
    {
        private const string DefaultUrlRootApi = "https://maps.googleapis.com/maps/api";
        public string ApiKey { get; set; }
        public string UrlRootApi { get; set; }
        public GoogleMapsApiSettings(string apiKey)
        {
            ApiKey = apiKey;
            UrlRootApi = DefaultUrlRootApi;
        }
    }
}
