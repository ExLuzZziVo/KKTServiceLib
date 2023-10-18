#region

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using CoreLib.CORE.Helpers.Converters;

#endregion

namespace KKTServiceLib.Atol.Types.Enums
{
    /// <summary>
    /// Система налогообложения
    /// </summary>
    [JsonConverter(typeof(JsonCamelCaseStringEnumConverter))]
    public enum TaxationType : byte
    {
        /// <summary>
        /// Общая
        /// </summary>
        [Display(Name = "Общая")] Osn,

        /// <summary>
        /// Упрощенная (Доход)
        /// </summary>
        [Display(Name = "Упрощенная (Доход)")] UsnIncome,

        /// <summary>
        /// Упрощенная (Доход минус Расход)
        /// </summary>
        [Display(Name = "Упрощенная (Доход минус Расход)")]
        UsnIncomeOutcome,

        /// <summary>
        /// Единый сельскохозяйственный налог
        /// </summary>
        [Display(Name = "Единый сельскохозяйственный налог")]
        Esn,

        /// <summary>
        /// Патентная
        /// </summary>
        [Display(Name = "Патентная")] Patent
    }
}