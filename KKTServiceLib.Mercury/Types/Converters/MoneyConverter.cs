#region

using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using CoreLib.CORE.Helpers.ObjectHelpers;

#endregion

namespace KKTServiceLib.Mercury.Types.Converters
{
    /// <summary>
    /// Конвертер для денежных величин. ККТ работает с int
    /// </summary>
    public class MoneyConverter: JsonConverter<object>
    {
        public override void Write(Utf8JsonWriter writer, object value, JsonSerializerOptions options)
        {
            if (value == null)
            {
                writer.WriteNullValue();

                return;
            }

            if (!(value is decimal dec))
            {
                throw new JsonException(
                    $"Unexpected value when converting amount. Expected Decimal but got {value.GetType()}.");
            }

            writer.WriteNumberValue((int)(Math.Round(dec, 2, MidpointRounding.AwayFromZero) * 100));
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
                    throw new JsonException($"Cannot convert '{str}' to decimal");
                }

                value = val;
            }

            return value / 100M;
        }

        public override bool CanConvert(Type typeToConvert)
        {
            return typeToConvert == typeof(decimal) || typeToConvert == typeof(decimal?);
        }
    }
}