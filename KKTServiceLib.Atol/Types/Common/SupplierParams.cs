#region

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using CoreLib.CORE.Helpers.ObjectHelpers;
using CoreLib.CORE.Helpers.StringHelpers;
using CoreLib.CORE.Resources;
using KKTServiceLib.Shared.Helpers;
using KKTServiceLib.Shared.Types.ValidationAttributes;

#endregion

namespace KKTServiceLib.Atol.Types.Common
{
    [Description("Параметры поставщика")]
    public class SupplierParams
    {
        /// <summary>
        /// Параметры поставщика
        /// </summary>
        /// <param name="name">Наименование</param>
        /// <param name="vatin">ИНН</param>
        /// <param name="phones">Телефоны</param>
        public SupplierParams(string name, string vatin, ISet<string> phones)
        {
            if (name.IsNullOrEmptyOrWhiteSpace())
            {
                throw new ArgumentException(
                    string.Format(ValidationStrings.ResourceManager.GetString("StringFormatError"),
                        GetType().GetProperty(nameof(Name)).GetPropertyDisplayName()), nameof(name));
            }

            if (vatin.IsNullOrEmptyOrWhiteSpace() || !Regex.IsMatch(vatin, RegexExtensions_Ru.VatinPattern))
            {
                throw new ArgumentException(
                    string.Format(ValidationStrings.ResourceManager.GetString("StringFormatError"),
                        GetType().GetProperty(nameof(Vatin)).GetPropertyDisplayName()), nameof(vatin));
            }

            if (phones?.Any() != true)
            {
                throw new ArgumentException(string.Format(
                        ValidationStrings.ResourceManager.GetString("CollectionMinLengthError"),
                        GetType().GetProperty(nameof(Phones)).GetPropertyDisplayName(), 1),
                    nameof(phones));
            }

            Name = name;
            Vatin = vatin;
            Phones = phones;
        }

        /// <summary>
        /// Телефоны поставщика
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// <item>Минимальное кол-во элементов: 1</item>
        /// <item>Все элементы должны соответствовать регулярному выражению <see cref="RegexHelper.PhoneNumberPattern"/></item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [RegularExpressionCollectionValidation(RegexHelper.PhoneNumberPattern)]
        [MinLength(1, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "CollectionMinLengthError")]
        [Display(Name = "Телефоны поставщика")]
        public ISet<string> Phones { get; }

        /// <summary>
        /// Наименование поставщика
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Наименование поставщика")]
        public string Name { get; }

        /// <summary>
        /// ИНН поставщика
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// <item>Должно соответствовать регулярному выражению <see cref="RegexExtensions_Ru.VatinPattern"/></item>
        /// </list>
        [RegularExpression(RegexExtensions_Ru.VatinPattern, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringFormatError")]
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "ИНН поставщика")]
        public string Vatin { get; }

        /// <summary>
        /// Печатать реквизит "Данные поставщика" (тег 1224)
        /// </summary>
        /// <remarks>
        /// Значение по умолчанию: true
        /// </remarks>
        [Display(Name = "Печатать реквизит \"Данные поставщика\"")]
        public bool SupplierPrint { get; set; } = true;

        /// <summary>
        /// Печатать реквизит "ИНН поставщика" (тег 1226)
        /// </summary>
        /// <remarks>
        /// Значение по умолчанию: true
        /// </remarks>
        [Display(Name = "Печатать реквизит \"ИНН поставщика\"")]
        public bool SupplierVatinPrint { get; set; } = true;
    }
}