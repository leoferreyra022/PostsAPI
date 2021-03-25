using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPI.Helpers
{
    public static class HttpHelper
    {
        public static string GetBaseUrlFromRequest(HttpRequest httpRequest)
        {
            return $"{httpRequest.Scheme}://{httpRequest.Host.ToUriComponent()}";
        }

        public static string GetFullUriPath(HttpRequest httpRequest, string uriSubPath)
        {
            return $"{GetBaseUrlFromRequest(httpRequest)}/{uriSubPath}";
        }
    }
}
