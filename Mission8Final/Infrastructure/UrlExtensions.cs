using System;
using Microsoft.AspNetCore.Http;

namespace Mission8Final.Infrastructure
{
    public static class UrlExtensions
    {
        // make a static function to get the value of querystring in the request
        public static string PathAndQuery(this HttpRequest request) => request.QueryString.HasValue ? $"{request.QueryString}" : request.Path.ToString();
    }
}
