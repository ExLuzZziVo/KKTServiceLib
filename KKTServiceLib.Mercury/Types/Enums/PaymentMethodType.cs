#region

using System.ComponentModel.DataAnnotations;

#endregion

namespace KKTServiceLib.Mercury.Types.Enums
{
    /// <summary>
    /// Способ расчета
    /// </summary>
    public enum PaymentMethodType : byte
    {
        /// <summary>
        /// Предоплата 100%
        /// </summary>
        [Display(Name = "Предоплата 100%")] FullPrepayment = 1,

        /// <summary>
        /// Предоплата
        /// </summary>
        [Display(Name = "Предоплата")] Prepayment = 2,

        /// <summary>
        /// Аванс
        /// </summary>
        [Display(Name = "Аванс")] Advance = 3,

        /// <summary>
        /// Полный расчет
        /// </summary>
        [Display(Name = "Полный расчет")] FullPayment = 4,

        /// <summary>
        /// Частичный расчет и кредит
        /// </summary>
        [Display(Name = "Частичный расчет и кредит")]
        PartialPayment = 5,

        /// <summary>
        /// Передача в кредит
        /// </summary>
        [Display(Name = "Передача в кредит")] Credit = 6,

        /// <summary>
        /// Оплата кредита
        /// </summary>
        [Display(Name = "Оплата кредита")] CreditPayment = 7
    }
}