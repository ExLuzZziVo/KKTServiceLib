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
    /// Тип чека коррекции
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter), typeof(CamelCaseNamingStrategy))]
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