using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace KKTServiceLib.Atol.Types.Enums
{
    /// <summary>
    /// Код обработки запроса
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter), typeof(CamelCaseNamingStrategy))]
    public enum MarkingCodeCheckResponseResult : byte
    {
        /// <summary>
        /// Запрос имеет корректный формат, в том числе корректный формат кода маркировки
        /// </summary>
        [Display(Name = "Запрос имеет корректный формат, в том числе корректный формат кода маркировки")]
        Correct,

        /// <summary>
        /// Запрос имеет некорректный формат
        /// </summary>
        [Display(Name = "Запрос имеет некорректный формат")]
        Incorrect,

        /// <summary>
        /// Указанный в запросе код маркировки имеет некорректный формат (не распознан)
        /// </summary>
        [Display(Name = "Указанный в запросе код маркировки имеет некорректный формат (не распознан)")]
        Unrecognized
    }
}