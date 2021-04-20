#region

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

#endregion

namespace AtolKKTServiceLib.Types.Enums
{
    /// <summary>
    /// Обрезание текста
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter), typeof(CamelCaseNamingStrategy))]
    public enum WrapType : byte
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