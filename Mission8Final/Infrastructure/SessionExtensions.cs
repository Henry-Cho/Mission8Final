using System;
using System.Text.Json;
using Microsoft.AspNetCore.Http;

namespace Mission8Final.Infrastructure
{
    public static class SessionExtensions
    {
        // Set json info
        public static void SetJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonSerializer.Serialize(value));
        }
        // Get json info
        public static T GetJson<T>(this ISession session, string key)
        {
            var sessionData = session.GetString(key);

            return sessionData == null ? default(T) : JsonSerializer.Deserialize<T>(sessionData);
        }
    }
}
