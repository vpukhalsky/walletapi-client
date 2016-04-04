using System;
using System.ComponentModel;
using Newtonsoft.Json;

namespace WalletApiClient.Common
{
    public class DefaultJsonEnumConverter : JsonConverter
    {
        /// <summary>
        /// Writes the JSON representation of the object.
        /// </summary>
        /// <param name="writer">The <see cref="T:Newtonsoft.Json.JsonWriter"/> to write to.</param><param name="value">The value.</param><param name="serializer">The calling serializer.</param>
        public override void WriteJson(JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer)
        {
            writer.WriteValue(((int)value).ToString());
        }

        /// <summary>
        /// Reads the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The <see cref="T:Newtonsoft.Json.JsonReader"/> to read from.</param><param name="objectType">Type of the object.</param><param name="existingValue">The existing value of object being read.</param><param name="serializer">The calling serializer.</param>
        /// <returns>
        /// The object value.
        /// </returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, Newtonsoft.Json.JsonSerializer serializer)
        {
            if (IsNullableType(objectType))
            {
                var nc = new NullableConverter(objectType);
                objectType = nc.UnderlyingType;
            }

            try
            {
                return Enum.Parse(objectType, reader.Value.ToString());
            }
            catch (Exception)
            {
                return null;
            }
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType.IsEnum;
        }

        private static bool IsNullableType(Type theType)
        {
            return (theType.IsGenericType && theType.GetGenericTypeDefinition() == typeof(Nullable<>));
        }
    }
}
