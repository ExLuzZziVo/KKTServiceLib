#region

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using KKTServiceLib.Shared.Helpers;
using KKTServiceLib.Shared.Resources;
using KKTServiceLib.Shared.Types.ValidationAttributes;

#endregion

namespace AtolKKTServiceLib.Types.Common.Agent
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
                    string.Format(ErrorStrings.ResourceManager.GetString("StringFormatError"),
                        this.GetType().GetProperty(nameof(Name)).GetDisplayName()),
                    nameof(name));
            }

            if (address.IsNullOrEmptyOrWhiteSpace())
            {
                throw new ArgumentException(
                    string.Format(ErrorStrings.ResourceManager.GetString("StringFormatError"),
                        this.GetType().GetProperty(nameof(Address)).GetDisplayName()),
                    nameof(address));
            }

            if (vatin.IsNullOrEmptyOrWhiteSpace() || !Regex.IsMatch(vatin, RegexHelper.VatinPattern))
            {
                throw new ArgumentException(
                    string.Format(ErrorStrings.ResourceManager.GetString("StringFormatError"),
                        this.GetType().GetProperty(nameof(Vatin)).GetDisplayName()),
                    nameof(vatin));
            }

            if (phones?.Any() != true)
            {
                throw new ArgumentException(string.Format(ErrorStrings.ResourceManager.GetString("MinLengthError"),
                        this.GetType().GetProperty(nameof(Phones)).GetDisplayName(), 1),
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
        [MinLength(1, ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "MinLengthError")]
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Телефоны оператора перевода")]
        public ISet<string> Phones { get; }

        /// <summary>
        /// Наименование оператора перевода
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Наименование оператора перевода")]
        public string Name { get; }

        /// <summary>
        /// Адрес оператора перевода
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Адрес оператора перевода")]
        public string Address { get; }

        /// <summary>
        /// ИНН оператора перевода
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// <item>Должно соответствовать регулярному выражению <see cref="RegexHelper.VatinPattern"/></item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "ИНН оператора перевода")]
        [RegularExpression(RegexHelper.VatinPattern, ErrorMessageResourceType = typeof(ErrorStrings),
            ErrorMessageResourceName = "StringFormatError")]
        public string Vatin { get; }
    }
}