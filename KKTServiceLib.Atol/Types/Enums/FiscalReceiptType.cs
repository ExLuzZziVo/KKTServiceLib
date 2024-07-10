#region

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using CoreLib.CORE.Helpers.Converters;

#endregion

namespace KKTServiceLib.Atol.Types.Enums
{
    /// <summary>
    /// Тип фискального чека
    /// </summary>
    [JsonConverter(typeof(JsonCamelCaseStringEnumConverter))]
    public enum FiscalReceiptType: byte
    {
        /// <summary>
        /// Чек прихода
        /// </summary>
        [Display(Name = "Чек прихода")] Sell,

        /// <summary>
        /// Чек расхода
        /// </summary>
        [Display(Name = "Чек расхода")] Buy,

        /// <summary>
        /// Чек возврата прихода
        /// </summary>
        [Display(Name = "Чек возврата прихода")]
        SellReturn,

        /// <summary>
        /// Чек возврата расхода
        /// </summary>
        [Display(Name = "Чек возврата расхода")]
        BuyReturn
    }
}