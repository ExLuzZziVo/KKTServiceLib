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

namespace KKTServiceLib.Atol.Types.Common.Agent
{
    [Description("Данные оператора перевода")]
    public class MoneyTransferOperatorParams
    {
        /// <summary>
        /// Данные оператора перевода
        /// </summary>
        /// <param name="name">Наименование</param>
        /// <param name="address">Адрес</param>
        /// <param name="vatin">ИНН</param>
        /// <param name="phones">Телефоны</param>
        public MoneyTransferOperatorParams(string name, string address, string vatin, ISet<string> phones)
        {
            if (name.IsNullOrEmptyOrWhiteSpace())
            {
                throw new ArgumentException(
                    string.Format(ValidationStrings.ResourceManager.GetString("StringFormatError"),
                        GetType().GetProperty(nameof(Name)).GetPropertyDisplayName()),
                    nameof(name));
            }

            if (address.IsNullOrEmptyOrWhiteSpace())
            {
                throw new ArgumentException(
                    string.Format(ValidationStrings.ResourceManager.GetString("StringFormatError"),
                        GetType().GetProperty(nameof(Address)).GetPropertyDisplayName()),
                    nameof(address));
            }

            if (vatin.IsNullOrEmptyOrWhiteSpace() || !Regex.IsMatch(vatin, RegexExtensions_Ru.VatinPattern))
            {
                throw new ArgumentException(
                    string.Format(ValidationStrings.ResourceManager.GetString("StringFormatError"),
                        GetType().GetProperty(nameof(Vatin)).GetPropertyDisplayName()),
                    nameof(vatin));
            }

            if (phones?.Any() != true)
            {
                throw new ArgumentException(string.Format(
                        ValidationStrings.ResourceManager.GetString("CollectionMinLengthError"),
                        GetType().GetProperty(nameof(Phones)).GetPropertyDisplayName(), 1),
                    nameof(phones));
            }

            Name = name;
            Address = address;
            Vatin = vatin;
            Phones = phones;
        }

        /// <summary>
        /// Телефоны оператора перевода
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// <item>Минимальное кол-во элементов: 1</item>
        /// <item>Все элементы должны соответствовать регулярному выражению <see cref="RegexHelper.PhoneNumberPattern"/></item>
        /// </list>
        [RegularExpressionCollectionValidation(RegexHelper.PhoneNumberPattern)]
        [MinLength(1, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "CollectionMinLengthError")]
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Телефоны оператора перевода")]
        public ISet<string> Phones { get; }

        /// <summary>
        /// Наименование оператора перевода
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Наименование оператора перевода")]
        public string Name { get; }

        /// <summary>
        /// Адрес оператора перевода
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Адрес оператора перевода")]
        public string Address { get; }

        /// <summary>
        /// ИНН оператора перевода
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// <item>Должно соответствовать регулярному выражению <see cref="RegexExtensions_Ru.VatinPattern"/></item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "ИНН оператора перевода")]
        [RegularExpression(RegexExtensions_Ru.VatinPattern, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringFormatError")]
        public string Vatin { get; }
    }
}