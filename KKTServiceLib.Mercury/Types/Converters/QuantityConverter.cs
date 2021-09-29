using System;
using Newtonsoft.Json;

namespace KKTServiceLib.Mercury.Types.Converters
{
    /// <summary>
    /// Конвертер параметров типа "Количество". ККТ работает с int
    /// </summary>
    public class QuantityConverter : JsonConverter<double>
    {
        public override void WriteJson(JsonWriter writer, double value, JsonSerializer serializer)
        {
            writer.WriteValue((int)(Math.Round(value, 4, MidpointRounding.AwayFromZero) * 10000));
        }

        public override double ReadJson(JsonReader reader, Type objectType, double existingValue, bool hasExistingValue,
            JsonSerializer serializer)
        {
            var value = (long?)reader.Value;

            return value == null ? 0 : (double)value / 10000;
        }
    }
}