using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Flexerant.ClubhouseSharp
{
    internal static class ExtensionMethods
    {
        private readonly static JsonSerializerSettings _jsonSerializerSettings;
        static ExtensionMethods()
        {
            _jsonSerializerSettings = new JsonSerializerSettings
            {
                MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
                DateParseHandling = DateParseHandling.None,
                Converters = { new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal } },
            };
        }

        public static async Task<JObject> DeserializeAsync<T>(this HttpResponseMessage httpResponseMessage)
        {
            if (!httpResponseMessage.IsSuccessStatusCode) throw new HttpRequestException(await httpResponseMessage.Content.ReadAsStringAsync());

            return JObject.Parse(await httpResponseMessage.Content.ReadAsStringAsync());
        }

        public static string Serialize<T>(this JsonObjectBase<T> obj)
        {
            return JsonConvert.SerializeObject(obj, _jsonSerializerSettings);
        }
    }
}
