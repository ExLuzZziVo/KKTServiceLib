using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace KKTServiceLib.Atol.Types.Enums
{
    /// <summary>
    /// Сведения о статусе товара
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter), typeof(CamelCaseNamingStrategy))]
    public enum MarkingCodeCheckItemStatusResult : byte
    {
        /// <summary>
        /// Планируемый статус товара корректен
        /// </summary>
        [Display(Name = "Планируемый статус товара корректен")]
        ItemEstimatedStatusCorrect,

        /// <summary>
        /// Планируемый статус товара некорректен
        /// </summary>
        [Display(Name = "Планируемый статус товара некорректен")]
        ItemEstimatedStatusIncorrect,

        /// <summary>
        /// Оборот товара приостановлен
        /// </summary>
        [Display(Name = "Оборот товара приостановлен")]
        ItemSaleStopped
    }
}