using NetCore.GoogleMapsApi.Interfaces;

namespace NetCore.GoogleMapsApi
{
    public class GoogleMapsApiService
    {
        #region Members
        private GoogleMapsApiSettings _settings;
        private IGoogleMapsDistanceMatrix _distanceMatrix;
        private IGoogleMapsGeoLocation _geolocation;
        #endregion

        #region Constructor
        public GoogleMapsApiService(GoogleMapsApiSettings settings)
        {
            _settings = settings;
        }
        #endregion

        #region Properties
        public IGoogleMapsDistanceMatrix DistanceMatrix
        {
            get
            {
                if (_distanceMatrix == null)
                    _distanceMatrix = new GoogleMapsDistanceMatrix(_settings);
                return _distanceMatrix;
            }
        }
        public IGoogleMapsGeoLocation GeoLocation
        {
            get
            {
                if (_geolocation == null)
                    _geolocation = new GoogleMapsGeoLocation(_settings);
                return _geolocation;
            }
        }
        #endregion
    }
}
