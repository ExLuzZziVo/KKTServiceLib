#region

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using CoreLib.CORE.Helpers.Converters;

#endregion

namespace KKTServiceLib.Atol.Types.Enums
{
    /// <summary>
    /// Способ расчета
    /// </summary>
    [JsonConverter(typeof(JsonCamelCaseStringEnumConverter))]
    public enum PaymentMethodType : byte
    {
        /// <summary>
        /// Предоплата 100%
        /// </summary>
        [Display(Name = "Предоплата 100%")] FullPrepayment,

        /// <summary>
        /// Предоплата
        /// </summary>
        [Display(Name = "Предоплата")] Prepayment,

        /// <summary>
        /// Аванс
        /// </summary>
        [Display(Name = "Аванс")] Advance,

        /// <summary>
        /// Полный расчет
        /// </summary>
        [Display(Name = "Полный расчет")] FullPayment,

        /// <summary>
        /// Частичный расчет и кредит
        /// </summary>
        [Display(Name = "Частичный расчет и кредит")]
        PartialPayment,

        /// <summary>
        /// Передача в кредит
        /// </summary>
        [Display(Name = "Передача в кредит")] Credit,

        /// <summary>
        /// Оплата кредита
        /// </summary>
        [Display(Name = "Оплата кредита")] CreditPayment
    }
}