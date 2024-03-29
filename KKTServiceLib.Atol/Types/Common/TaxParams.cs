#region

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using CoreLib.CORE.Resources;
using KKTServiceLib.Atol.Types.Enums;

#endregion

namespace KKTServiceLib.Atol.Types.Common
{
    [Description("Налог")]
    public class TaxParams
    {
        /// <summary>
        /// Налог
        /// </summary>
        /// <param name="type">Налоговая ставка</param>
        public TaxParams(WatType type)
        {
            Type = type;
        }

        /// <summary>
        /// Налоговая ставка
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Налоговая ставка")]
        public WatType Type { get; }

        /// <summary>
        /// Сумма налога
        /// </summary>
        /// <list type="bullet">
        /// <item>Должно лежать в диапазоне: 0-<see cref="decimal.MaxValue"/></item>
        /// </list>
        [Display(Name = "Сумма налога")]
        [Range(0, (double)decimal.MaxValue, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "DigitRangeValuesError")]
        public decimal? Sum { get; set; }
    }
}