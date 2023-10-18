#region

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using CoreLib.CORE.Helpers.ObjectHelpers;
using CoreLib.CORE.Helpers.StringHelpers;
using CoreLib.CORE.Resources;
using KKTServiceLib.Atol.Types.Enums;

#endregion

namespace KKTServiceLib.Atol.Types.Common
{
    [Description("Информация об организации-пользователе")]
    public class OrganizationParams
    {
        /// <summary>
        /// Информация об организации-пользователе
        /// </summary>
        /// <param name="name">Название</param>
        /// <param name="vatin">ИНН</param>
        /// <param name="address">Адрес расчетов</param>
        /// <param name="taxationTypes">Список систем налогообложения</param>
        public OrganizationParams(string name, string vatin, string address, ISet<TaxationType> taxationTypes)
        {
            if (name.IsNullOrEmptyOrWhiteSpace())
            {
                throw new ArgumentException(
                    string.Format(
                        ValidationStrings.ResourceManager.GetString("StringFormatError"),
                        GetType().GetProperty(nameof(Name)).GetPropertyDisplayName()),
                    nameof(name));
            }

            if (vatin.IsNullOrEmptyOrWhiteSpace() || !Regex.IsMatch(vatin, RegexExtensions_Ru.VatinPattern))
            {
                throw new ArgumentException(
                    string.Format(
                        ValidationStrings.ResourceManager.GetString("StringFormatError"),
                        GetType().GetProperty(nameof(Vatin)).GetPropertyDisplayName()),
                    nameof(vatin));
            }

            if (address.IsNullOrEmptyOrWhiteSpace())
            {
                throw new ArgumentException(
                    string.Format(
                        ValidationStrings.ResourceManager.GetString("StringFormatError"),
                        GetType().GetProperty(nameof(Address)).GetPropertyDisplayName()),
                    nameof(address));
            }

            if (taxationTypes?.Any() != true)
            {
                throw new ArgumentException(string.Format(
                        ValidationStrings.ResourceManager.GetString("CollectionMinLengthError"),
                        GetType().GetProperty(nameof(TaxationTypes)).GetPropertyDisplayName(), 1),
                    nameof(taxationTypes));
            }

            Name = name;
            Vatin = vatin;
            Address = address;
            TaxationTypes = taxationTypes;
        }

        [JsonConstructor]
        private OrganizationParams() { }

        /// <summary>
        /// Название организации-пользователя
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Название организации-пользователя")]
        public string Name { get; }

        /// <summary>
        /// ИНН организации-пользователя
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// <item>Должно соответствовать регулярному выражению <see cref="RegexExtensions_Ru.VatinPattern"/></item>
        /// </list>
        [RegularExpression(RegexExtensions_Ru.VatinPattern, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringFormatError")]
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "ИНН организации-пользователя")]
        public string Vatin { get; }

        /// <summary>
        /// E-mail организации (адрес отравителя электронных чеков)
        /// </summary>
        /// <list type="bullet">
        /// <item>Должно соответствовать регулярному выражению <see cref="RegexExtensions.EmailAddressPattern"/></item>
        /// </list>
        [RegularExpression(RegexExtensions.EmailAddressPattern,
            ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "StringFormatError")]
        [Display(Name = "E-mail организации (адрес отравителя электронных чеков)")]
        public string Email { get; set; }

        /// <summary>
        /// Адрес расчетов
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Адрес расчетов")]
        public string Address { get; }

        /// <summary>
        /// Список систем налогообложения
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// <item>Минимальное кол-во элементов: 1</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [MinLength(1, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "CollectionMinLengthError")]
        [Display(Name = "Список систем налогообложения")]
        public ISet<TaxationType> TaxationTypes { get; }

        /// <summary>
        /// Признак агента
        /// </summary>
        [Display(Name = "Признак агента")]
        public ISet<AgentType> Agents { get; set; }
    }
}