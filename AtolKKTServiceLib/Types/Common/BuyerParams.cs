#region

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using KKTServiceLib.Shared.Helpers;
using KKTServiceLib.Shared.Resources;

#endregion

namespace AtolKKTServiceLib.Types.Common
{
    [Description("Информация о покупателе")]
    public class BuyerParams
    {
        /// <summary>
        /// E-mail или номер телефона покупателя
        /// </summary>
        /// <list type="bullet">
        /// <item>Должно соответствовать регулярному выражению <see cref="RegexHelper.EmailAddressOrPhoneNumberPattern"/></item>
        /// </list>
        [RegularExpression(
            RegexHelper.EmailAddressOrPhoneNumberPattern,
            ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "StringFormatError")]
        [Display(Name = "E-mail или номер телефона покупателя")]
        public string EmailOrPhone { get; set; }

        /// <summary>
        /// ИНН покупателя
        /// </summary>
        /// <list type="bullet">
        /// <item>Должно соответствовать регулярному выражению <see cref="RegexHelper.VatinPattern"/></item>
        /// </list>
        [RegularExpression(RegexHelper.VatinPattern, ErrorMessageResourceType = typeof(ErrorStrings),
            ErrorMessageResourceName = "StringFormatError")]
        [Display(Name = "ИНН покупателя")]
        public string Vatin { get; set; }

        /// <summary>
        /// Наименование покупателя
        /// </summary>
        [Display(Name = "Наименование покупателя")]
        public string Name { get; set; }
    }
}