#region

using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

#endregion

namespace KKTServiceLib.Atol.Types.Enums
{
    /// <summary>
    /// Система налогообложения
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter), typeof(CamelCaseNamingStrategy))]
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