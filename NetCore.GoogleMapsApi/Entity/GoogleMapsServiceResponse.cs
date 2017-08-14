using NetCore.GoogleMapsApi.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore.GoogleMapsApi.Entity
{
    public class GoogleMapsServiceResponse<T>
    {
        public GoogleMapsResponseStatus Status { get; set; }
        public T Result { get; set; }
        public Exception Exception { get; set; }
        public GoogleMapsServiceResponse()
        {
            Status = GoogleMapsResponseStatus.OK;
        }
    }
}
