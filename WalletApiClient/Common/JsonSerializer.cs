using System.Collections.Generic;
using Newtonsoft.Json;

namespace WalletApiClient.Common
{
    /// <summary>
    /// Serialize/deserialize types to/from json.
    /// </summary>
    public class JsonSerializer
    {
        private static readonly JsonSerializerSettings JsonSettings;

        private readonly JsonSerializerSettings _currentSerttings;

        static JsonSerializer()
        {
            JsonSettings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                PreserveReferencesHandling =
                    PreserveReferencesHandling.Objects,
                ReferenceLoopHandling =
                    ReferenceLoopHandling.Serialize,
                Converters =
                    new List<JsonConverter> { new JsonEnumConverter() }
            };
        }

        public JsonSerializer()
            : this(JsonSettings)
        { }

        public JsonSerializer(JsonSerializerSettings serializerSettings)
        {
            _currentSerttings = serializerSettings;
        }

        #region ISerializer members

        public string Serialize<T>(T value)
        {
            return JsonConvert.SerializeObject(value, Formatting.None, _currentSerttings);
        }

        public T Deserialize<T>(string value)
        {
            return JsonConvert.DeserializeObject<T>(value, _currentSerttings);
        }

        #endregion
    }
}
