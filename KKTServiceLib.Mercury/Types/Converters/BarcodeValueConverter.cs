#region

using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using KKTServiceLib.Shared.Helpers;

#endregion

namespace KKTServiceLib.Mercury.Types.Converters
{
    /// <summary>
    /// Конвертер значения штрихового кода
    /// </summary>
    public class BarcodeValueConverter : JsonConverter<string>
    {
        public override void Write(Utf8JsonWriter writer, string value, JsonSerializerOptions options)
        {
            if (Regex.IsMatch(value, RegexHelper.BarcodePattern))
            {
                writer.WriteNumberValue(long.Parse(value));
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(value));
            }
        }

        public override string Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.Null)
            {
                return null;
            }

            string value;

            if (reader.TryGetInt64(out var val))
            {
                value = val.ToString();
            }
            else
            {
                value = reader.GetString();

                if (string.IsNullOrEmpty(value))
                {
                    return null;
                }
            }

            return Regex.IsMatch(value, RegexHelper.BarcodePattern) ? value : null;
        }
    }
}