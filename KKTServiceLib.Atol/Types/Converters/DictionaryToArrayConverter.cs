#region

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

#endregion

namespace KKTServiceLib.Atol.Types.Converters
{
    public class DictionaryToArrayConverter<TKey, TValue> : JsonConverter<IDictionary<TKey, TValue>>
    {
        public override void Write(Utf8JsonWriter writer, IDictionary<TKey, TValue> value,
            JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value.ToArray(), options);
        }

        public override IDictionary<TKey, TValue> Read(ref Utf8JsonReader reader, Type typeToConvert,
            JsonSerializerOptions options)
        {
            var dictionary = JsonSerializer.Deserialize<KeyValuePair<TKey, TValue>[]>(ref reader, options)
                ?.ToDictionary(kv => kv.Key, kv => kv.Value);

            if (typeToConvert == typeof(ReadOnlyDictionary<TKey, TValue>))
            {
                return Activator.CreateInstance(typeToConvert, dictionary) as IDictionary<TKey, TValue>;
            }

            return dictionary;
        }

        public override bool CanConvert(Type typeToConvert)
        {
            if (typeToConvert.IsInterface && typeToConvert.GetGenericTypeDefinition() == typeof(IDictionary<,>))
            {
                return true;
            }

            foreach (var i in typeToConvert.GetInterfaces())
            {
                if (i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IDictionary<,>))
                {
                    return true;
                }
            }

            return false;
        }
    }
}