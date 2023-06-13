using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace UkwWypozyczalnia.Infrastructure
{
    public static class SessionHelper
    {

        public static void SetObjAsJSON(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T GetObjFromJSON<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }
}
