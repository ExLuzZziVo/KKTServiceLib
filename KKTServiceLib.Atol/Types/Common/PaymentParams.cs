#region

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using KKTServiceLib.Atol.Types.Enums;
using KKTServiceLib.Atol.Types.Interfaces;
using KKTServiceLib.Shared.Helpers;
using KKTServiceLib.Shared.Resources;
using KKTServiceLib.Shared.Types.ValidationAttributes;

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
                    string.Format(ErrorStrings.ResourceManager.GetString("DigitRangeValuesError"),
                        GetType().GetProperty(nameof(Sum)).GetDisplayName(), 0.01, decimal.MaxValue),
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
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Способ расчета")]
        public PaymentType Type { get; }

        /// <summary>
        /// Сумма расчета
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// <item>Должно лежать в диапазоне: 0.01-<see cref="decimal.MaxValue"/></item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Сумма расчета")]
        [Range(0.01, (double)decimal.MaxValue, ErrorMessageResourceType = typeof(ErrorStrings),
            ErrorMessageResourceName = "DigitRangeValuesError")]
        public decimal Sum { get; }

        /// <summary>
        /// Элементы для печати после оплаты
        /// </summary>
        [ComplexObjectCollectionValidation(AllowNullItems = false, ErrorMessageResourceType = typeof(ErrorStrings),
            ErrorMessageResourceName = "ComplexObjectCollectionValidationError")]
        [Display(Name = "Элементы для печати после оплаты")]
        public ICommonDocumentElement[] PrintItems { get; set; }
    }
}