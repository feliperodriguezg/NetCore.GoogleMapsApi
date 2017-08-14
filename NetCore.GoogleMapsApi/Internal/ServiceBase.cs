using NetCore.GoogleMapsApi.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore.GoogleMapsApi.Implementations
{
    internal abstract class ServiceBase
    {
        protected GoogleMapsApiSettings _settings;

        public ServiceBase(GoogleMapsApiSettings settings)
        {
            _settings = settings;
        }

        protected GoogleMapsResponseStatus GetEnumStatus(Base response)
        {
            return (GoogleMapsResponseStatus)Enum.Parse(typeof(GoogleMapsResponseStatus), response.status);
        }
    }
}
