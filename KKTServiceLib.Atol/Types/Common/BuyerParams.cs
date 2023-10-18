#region

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using CoreLib.CORE.Helpers.Converters;
using CoreLib.CORE.Helpers.StringHelpers;
using CoreLib.CORE.Resources;
using KKTServiceLib.Atol.Types.Enums;
using KKTServiceLib.Shared.Helpers;

#endregion

namespace KKTServiceLib.Atol.Types.Common
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
            ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "StringFormatError")]
        [Display(Name = "E-mail или номер телефона покупателя")]
        public string EmailOrPhone { get; set; }

        /// <summary>
        /// ИНН покупателя
        /// </summary>
        /// <list type="bullet">
        /// <item>Должно соответствовать регулярному выражению <see cref="RegexExtensions_Ru.VatinPattern"/></item>
        /// </list>
        [RegularExpression(RegexExtensions_Ru.VatinPattern, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringFormatError")]
        [Display(Name = "ИНН покупателя")]
        public string Vatin { get; set; }

        /// <summary>
        /// Наименование покупателя
        /// </summary>
        [Display(Name = "Наименование покупателя")]
        public string Name { get; set; }

        /// <summary>
        /// Дата рождения
        /// </summary>
        /// <remarks>
        /// Только для ФФД ≥ 1.2
        /// </remarks>
        [Display(Name = "Дата рождения")]
        [CustomDateTimeConverter("dd.MM.yyyy")]
        public DateTime? BirthDate { get; set; }

        /// <summary>
        /// Гражданство
        /// </summary>
        /// <list type="bullet">
        /// <item>Должно соответствовать регулярному выражению <see cref="RegexHelper.CountryOfOriginCodePattern"/></item>
        /// <item>Максимальная длина: 3</item>
        /// </list>
        /// <remarks>
        /// Только для ФФД ≥ 1.2
        /// </remarks>
        [Display(Name = "Гражданство")]
        [MaxLength(3, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringMaxLengthError")]
        [RegularExpression(RegexHelper.CountryOfOriginCodePattern, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringFormatError")]
        public string Citizenship { get; set; }

        /// <summary>
        /// Код вида документа, удостоверяющего личность
        /// </summary>
        /// <remarks>
        /// Только для ФФД ≥ 1.2
        /// </remarks>
        [Display(Name = "Код вида документа, удостоверяющего личность")]
        public IdentityDocumentType? IdentityDocumentCode { get; set; }

        /// <summary>
        /// Данные документа, удостоверяющего личность
        /// </summary>
        /// <remarks>
        /// Только для ФФД ≥ 1.2
        /// </remarks>
        [Display(Name = "Данные документа, удостоверяющего личность")]
        public string IdentityDocumentData { get; set; }

        /// <summary>
        /// Адрес покупателя/клиента
        /// </summary>
        /// <remarks>
        /// Только для ФФД ≥ 1.2
        /// </remarks>
        [Display(Name = "Адрес покупателя/клиента")]
        public string Address { get; set; }
    }
}