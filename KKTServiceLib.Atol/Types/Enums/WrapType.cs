#region

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using CoreLib.CORE.Helpers.Converters;

#endregion

namespace KKTServiceLib.Atol.Types.Enums
{
    /// <summary>
    /// Обрезание текста
    /// </summary>
    [JsonConverter(typeof(JsonCamelCaseStringEnumConverter))]
    public enum WrapType: byte
    {
        /// <summary>
        /// Не переносить, обрезать по ширине ленты
        /// </summary>
        [Display(Name = "Не переносить, обрезать по ширине ленты")]
        None,

        /// <summary>
        /// Посимвольный перенос
        /// </summary>
        [Display(Name = "Посимвольный перенос")]
        Chars,

        /// <summary>
        /// Перенос по словам
        /// </summary>
        [Display(Name = "Перенос по словам")] Words
    }
}