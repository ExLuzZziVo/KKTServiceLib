#region

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using CoreLib.CORE.Helpers.ValidationHelpers.Attributes;
using CoreLib.CORE.Resources;
using KKTServiceLib.Mercury.Types.Common;
using KKTServiceLib.Shared.Helpers;

#endregion

namespace KKTServiceLib.Mercury.Types.Operations.Fiscal.Receipt.CloseCheck
{
    [Description("Закрытие фискального чека")]
    public class CloseCheckOperation: Operation<CloseCheckResult>
    {
        /// <summary>
        /// Закрытие фискального чека
        /// </summary>
        /// <param name="payments">Суммы оплат по чеку</param>
        public CloseCheckOperation(PaymentParams payments): base("CloseCheck")
        {
            Payment = payments ?? throw new ArgumentNullException(nameof(payments));
        }

        /// <summary>
        /// E-mail или номер телефона покупателя
        /// </summary>
        /// <list type="bullet">
        /// <item>Должно соответствовать регулярному выражению <see cref="RegexHelper.EmailAddressOrPhoneNumberPattern"/></item>
        /// </list>
        [RegularExpression(RegexHelper.EmailAddressOrPhoneNumberPattern,
            ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "StringFormatError")]
        [Display(Name = "E-mail или номер телефона покупателя")]
        public string SendCheckTo { get; set; }

        /// <summary>
        /// Дополнительная информация для печати в чеке
        /// </summary>
        /// <list type="bullet">
        /// <item>Максимальная длина: 512</item>
        /// </list>
        [MaxLength(512, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringMaxLengthError")]
        [Display(Name = "Дополнительная информация для печати в чеке")]
        public string AddInfo { get; set; }

        /// <summary>
        /// Суммы оплат по чеку
        /// </summary>
        [Display(Name = "Суммы оплат по чеку")]
        [ComplexObjectValidation(ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "ComplexObjectValidationError")]
        public PaymentParams Payment { get; }
    }
}