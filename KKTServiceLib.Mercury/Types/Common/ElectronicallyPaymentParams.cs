#region

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using CoreLib.CORE.Resources;
using KKTServiceLib.Mercury.Types.Converters;

#endregion

namespace KKTServiceLib.Mercury.Types.Common
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
        /// <item>Должно лежать в диапазоне: 0.01-21474836</item>
        /// </list>
        [Display(Name = "Сумма оплаты безналичными")]
        [JsonConverter(typeof(MoneyConverter))]
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [Range(0.01, 21474836, ErrorMessageResourceType = typeof(ValidationStrings),
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
        public int? Method { get; set; }

        /// <summary>
        /// Идентификаторы безналичной оплаты
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// <item>Максимальная длина: 256</item>
        /// </list>
        [Display(Name = "Идентификаторы безналичной оплаты")]
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [MaxLength(256, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringMaxLengthError")]
        public string Ids { get; set; }

        /// <summary>
        /// Дополнительные сведения о безналичной оплате
        /// </summary>
        /// <list type="bullet">
        /// <item>Максимальная длина: 256</item>
        /// </list>
        [Display(Name = "Дополнительные сведения о безналичной оплате")]
        [MaxLength(256, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringMaxLengthError")]
        public string AddInfo { get; set; }
    }
}
