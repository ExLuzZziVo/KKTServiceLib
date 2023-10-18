#region

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using CoreLib.CORE.Helpers.Converters;

#endregion

namespace KKTServiceLib.Atol.Types.Enums
{
    /// <summary>
    /// Тип чека коррекции
    /// </summary>
    [JsonConverter(typeof(JsonCamelCaseStringEnumConverter))]
    public enum CorrectionReceiptType : byte
    {
        /// <summary>
        /// Чек коррекции прихода
        /// </summary>
        [Display(Name = "Чек коррекции прихода")]
        SellCorrection,

        /// <summary>
        /// Чек коррекции расхода
        /// </summary>
        [Display(Name = "Чек коррекции расхода")]
        BuyCorrection,

        /// <summary>
        /// Чек коррекции возврата прихода
        /// </summary>
        [Display(Name = "Чек коррекции возврата прихода")]
        SellReturnCorrection,

        /// <summary>
        /// Чек коррекции возврата расхода
        /// </summary>
        [Display(Name = "Чек коррекции возврата расхода")]
        BuyReturnCorrection
    }
}