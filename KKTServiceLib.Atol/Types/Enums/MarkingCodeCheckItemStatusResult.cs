#region

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using CoreLib.CORE.Helpers.Converters;

#endregion

namespace KKTServiceLib.Atol.Types.Enums
{
    /// <summary>
    /// Сведения о статусе товара
    /// </summary>
    [JsonConverter(typeof(JsonCamelCaseStringEnumConverter))]
    public enum MarkingCodeCheckItemStatusResult: byte
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