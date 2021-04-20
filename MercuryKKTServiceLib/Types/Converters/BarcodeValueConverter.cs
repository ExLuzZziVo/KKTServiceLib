using System;
using System.Text.RegularExpressions;
using KKTServiceLib.Shared.Helpers;
using Newtonsoft.Json;

namespace MercuryKKTServiceLib.Types.Converters
{
    /// <summary>
    /// Конвертер значения штрихового кода
    /// </summary>
    public class BarcodeValueConverter : JsonConverter<string>
    {
        public override void WriteJson(JsonWriter writer, string value, JsonSerializer serializer)
        {
            if (Regex.IsMatch(value, RegexHelper.BarcodePattern))
                writer.WriteValue(long.Parse(value));
            else
                throw new ArgumentOutOfRangeException(nameof(value));
        }

        public override string ReadJson(JsonReader reader, Type objectType, string existingValue, bool hasExistingValue,
            JsonSerializer serializer)
        {
            if (reader.Value != null)
            {
                var value = reader.Value.ToString();

                return Regex.IsMatch(value, RegexHelper.BarcodePattern) ? value : null;
            }

            return null;
        }
    }
}