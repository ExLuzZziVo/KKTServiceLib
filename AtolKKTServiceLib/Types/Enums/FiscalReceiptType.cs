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
    /// Тип фискального чека
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter), typeof(CamelCaseNamingStrategy))]
    public enum FiscalReceiptType : byte
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