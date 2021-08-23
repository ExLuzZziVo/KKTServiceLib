#region

using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

#endregion

namespace KKTServiceLib.Atol.Types.Enums
{
    /// <summary>
    /// Способ оплаты
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter), typeof(CamelCaseNamingStrategy))]
    public enum PaymentType : byte
    {
        /// <summary>
        /// Наличными
        /// </summary>
        [Display(Name = "Наличными")] Cash = 0,

        /// <summary>
        /// Безналичными
        /// </summary>
        [Display(Name = "Безналичными")] Electronically = 1,

        /// <summary>
        /// Предварительная оплата (аванс)
        /// </summary>
        [Display(Name = "Предварительная оплата (аванс)")]
        Prepaid = 2,

        /// <summary>
        /// Последующая оплата (кредит)
        /// </summary>
        [Display(Name = "Последующая оплата (кредит)")]
        Credit = 3,

        /// <summary>
        /// Иная форма оплаты (встречное предоставление)
        /// </summary>
        [Display(Name = "Иная форма оплаты (встречное предоставление)")]
        Other = 4
    }
}