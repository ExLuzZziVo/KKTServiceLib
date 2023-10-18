#region

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using CoreLib.CORE.Resources;
using KKTServiceLib.Mercury.Types.Converters;

#endregion

namespace KKTServiceLib.Mercury.Types.Common
{
    [Description("Оплаты чека")]
    public class PaymentParams
    {
        /// <summary>
        /// Сумма наличными
        /// </summary>
        /// <list type="bullet">
        /// <item>Должно лежать в диапазоне: 0.01-21474836/></item>
        /// </list>
        [Display(Name = "Сумма наличными")]
        [JsonConverter(typeof(MoneyConverter))]
        [Range(0.01, 21474836, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "DigitRangeValuesError")]
        public decimal? Cash { get; set; }

        /// <summary>
        /// Сумма безналичными
        /// </summary>
        /// <list type="bullet">
        /// <item>Должно лежать в диапазоне: 0.01-21474836/></item>
        /// </list>
        [Display(Name = "Сумма безналичными")]
        [JsonConverter(typeof(MoneyConverter))]
        [Range(0.01, 21474836, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "DigitRangeValuesError")]
        public decimal? Ecash { get; set; }

        /// <summary>
        /// Сумма предоплатой (аванс)
        /// </summary>
        /// <list type="bullet">
        /// <item>Должно лежать в диапазоне: 0.01-21474836/></item>
        /// </list>
        [Display(Name = "Сумма предоплатой (аванс)")]
        [JsonConverter(typeof(MoneyConverter))]
        [Range(0.01, 21474836, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "DigitRangeValuesError")]
        public decimal? Prepayment { get; set; }

        /// <summary>
        /// Сумма постоплатой (кредит)
        /// </summary>
        /// <list type="bullet">
        /// <item>Должно лежать в диапазоне: 0.01-21474836/></item>
        /// </list>
        [Display(Name = "Сумма постоплатой (кредит)")]
        [JsonConverter(typeof(MoneyConverter))]
        [Range(0.01, 21474836, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "DigitRangeValuesError")]
        public decimal? Credit { get; set; }

        /// <summary>
        /// Сумма встречным предоставлением
        /// </summary>
        /// <list type="bullet">
        /// <item>Должно лежать в диапазоне: 0.01-21474836/></item>
        /// </list>
        [Display(Name = "Сумма встречным предоставлением")]
        [JsonConverter(typeof(MoneyConverter))]
        [Range(0.01, 21474836, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "DigitRangeValuesError")]
        public decimal? Consideration { get; set; }
    }
}