#region

using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using CoreLib.CORE.Helpers.ObjectHelpers;

#endregion

namespace KKTServiceLib.Mercury.Types.Converters
{
    /// <summary>
    /// Конвертер параметров типа "Количество". ККТ работает с int
    /// </summary>
    public class QuantityConverter : JsonConverter<object>
    {
        public override void Write(Utf8JsonWriter writer, object value, JsonSerializerOptions options)
        {
            if (value == null)
            {
                writer.WriteNullValue();

                return;
            }

            if (!(value is double doub))
            {
                throw new JsonException(
                    $"Unexpected value when converting amount. Expected Decimal but got {value.GetType()}.");
            }

            writer.WriteNumberValue((int)(Math.Round(doub, 4, MidpointRounding.AwayFromZero) * 10000));
        }

        public override object Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var isNullable = typeToConvert.IsNullable();

            if (reader.TokenType == JsonTokenType.Null)
            {
                if (!isNullable)
                {
                    throw new JsonException($"Cannot convert null value to {typeToConvert}");
                }

                return null;
            }

            if (!reader.TryGetInt64(out var value))
            {
                var str = reader.GetString();

                if (isNullable && string.IsNullOrEmpty(str))
                {
                    return null;
                }

                if (!long.TryParse(str, out var val))
                {
                    throw new JsonException($"Cannot convert '{str}' to double");
                }

                value = val;
            }

            return value / 10000D;
        }

        public override bool CanConvert(Type typeToConvert)
        {
            return typeToConvert == typeof(double) || typeToConvert == typeof(double?);
        }
    }
}