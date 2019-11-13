using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace ElClima.Authorization.Session
{
    public static class AspNetCoreSessionExtensions
    {
        private static readonly JsonSerializerSettings SerializerSettings =
           new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };

        public static void SetObjectAsJson(this ISession session, string key, object value)
        {

            session.SetString(key, JsonConvert.SerializeObject(value, SerializerSettings));
        }

        public static T GetObjectFromJson<T>(this ISession session, string key)
        {
            var value = session.GetString(key);

            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }
}
