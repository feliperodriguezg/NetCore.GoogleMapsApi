using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore.GoogleMapsApi.Enums
{
    public enum GoogleMapsResponseStatus
    {
        OK,
        ZERO_RESULTS,
        OVER_QUERY_LIMIT,
        REQUEST_DENIED,
        INVALID_REQUEST,
        UNKNOWN_ERROR,
        /// <summary>
        /// Use for HttpRequestException
        /// </summary>
        BAD_REQUEST_ERROR
    }
}
