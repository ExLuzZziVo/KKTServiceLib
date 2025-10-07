#region

using System.ComponentModel.DataAnnotations;
using CoreLib.CORE.Resources;

#endregion

namespace KKTServiceLib.Atol.Types.Common
{
    /// <summary>
    /// Сведения об оплате безналичными
    /// </summary>
    public class ElectronicallyPaymentParams
    {
        /// <summary>
        /// Сумма оплаты безналичными
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// <item>Должно лежать в диапазоне: 0.01-<see cref="decimal.MaxValue"/></item>
        /// </list>
        [Display(Name = "Сумма оплаты безналичными")]
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [Range(0.01, (double)decimal.MaxValue, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "DigitRangeValuesError")]
        public decimal? Sum { get; set; }

        /// <summary>
        /// Признак способа оплаты безналичными
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        /// <remarks>
        /// Данные еще не утверждены ФНС
        /// </remarks>
        [Display(Name = "Признак способа оплаты безналичными")]
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        public int? PaymentMethod { get; set; }

        /// <summary>
        /// Идентификаторы безналичной оплаты
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Display(Name = "Идентификаторы безналичной оплаты")]
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        public string ElectronicallyId { get; set; }

        /// <summary>
        /// Дополнительные сведения о безналичной оплате
        /// </summary>
        [Display(Name = "Дополнительные сведения о безналичной оплате")]
        public string ElectronicallyAddInfo { get; set; }
    }
}
