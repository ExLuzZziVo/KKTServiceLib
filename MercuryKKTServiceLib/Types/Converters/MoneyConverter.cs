using System;
using Newtonsoft.Json;

namespace MercuryKKTServiceLib.Types.Converters
{
    /// <summary>
    /// Конвертер для денежных величин. ККТ работает с int
    /// </summary>
    public class MoneyConverter : JsonConverter<decimal>
    {
        public override void WriteJson(JsonWriter writer, decimal value, JsonSerializer serializer)
        {
            writer.WriteValue((int) Math.Round(value, 2, MidpointRounding.AwayFromZero) * 100);
        }

        public override decimal ReadJson(JsonReader reader, Type objectType, decimal existingValue,
            bool hasExistingValue,
            JsonSerializer serializer)
        {
            var value = (long?) reader.Value;

            return value == null ? 0 : (decimal) value / 100;
        }
    }
}