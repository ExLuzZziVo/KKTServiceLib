#region

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using CoreLib.CORE.Helpers.ObjectHelpers;
using CoreLib.CORE.Helpers.ValidationHelpers.Attributes;
using CoreLib.CORE.Resources;
using KKTServiceLib.Atol.Types.Enums;
using KKTServiceLib.Atol.Types.Interfaces;

#endregion

namespace KKTServiceLib.Atol.Types.Common
{
    [Description("Оплата чека")]
    public class PaymentParams
    {
        /// <summary>
        /// Оплата чека
        /// </summary>
        /// <param name="type">Способ расчета</param>
        /// <param name="sum">Сумма</param>
        public PaymentParams(PaymentType type, decimal sum)
        {
            if (sum < (decimal)0.01)
            {
                throw new ArgumentException(
                    string.Format(ValidationStrings.ResourceManager.GetString("DigitRangeValuesError"),
                        GetType().GetProperty(nameof(Sum)).GetPropertyDisplayName(), 0.01, decimal.MaxValue),
                    nameof(sum));
            }

            Type = type;
            Sum = sum;
        }

        /// <summary>
        /// Способ расчета
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Способ расчета")]
        public PaymentType Type { get; }

        /// <summary>
        /// Сумма расчета
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// <item>Должно лежать в диапазоне: 0.01-<see cref="decimal.MaxValue"/></item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Сумма расчета")]
        [Range(0.01, (double)decimal.MaxValue, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "DigitRangeValuesError")]
        public decimal Sum { get; }

        /// <summary>
        /// Элементы для печати после оплаты
        /// </summary>
        [ComplexObjectCollectionValidation(AllowNullItems = false, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "ComplexObjectCollectionValidationError")]
        [Display(Name = "Элементы для печати после оплаты")]
        public ICommonDocumentElement[] PrintItems { get; set; }
    }
}