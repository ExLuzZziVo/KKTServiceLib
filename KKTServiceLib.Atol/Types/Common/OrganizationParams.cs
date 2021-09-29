#region

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using KKTServiceLib.Atol.Types.Enums;
using KKTServiceLib.Shared.Helpers;
using KKTServiceLib.Shared.Resources;
using Newtonsoft.Json;

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
                        ErrorStrings.ResourceManager.GetString("StringFormatError"),
                        GetType().GetProperty(nameof(Name)).GetDisplayName()),
                    nameof(name));
            }

            if (vatin.IsNullOrEmptyOrWhiteSpace() || !Regex.IsMatch(vatin, RegexHelper.VatinPattern))
            {
                throw new ArgumentException(
                    string.Format(
                        ErrorStrings.ResourceManager.GetString("StringFormatError"),
                        GetType().GetProperty(nameof(Vatin)).GetDisplayName()),
                    nameof(vatin));
            }

            if (address.IsNullOrEmptyOrWhiteSpace())
            {
                throw new ArgumentException(
                    string.Format(
                        ErrorStrings.ResourceManager.GetString("StringFormatError"),
                        GetType().GetProperty(nameof(Address)).GetDisplayName()),
                    nameof(address));
            }

            if (taxationTypes?.Any() != true)
            {
                throw new ArgumentException(string.Format(ErrorStrings.ResourceManager.GetString("MinLengthError"),
                        GetType().GetProperty(nameof(TaxationTypes)).GetDisplayName(), 1),
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
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Название организации-пользователя")]
        public string Name { get; }

        /// <summary>
        /// ИНН организации-пользователя
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// <item>Должно соответствовать регулярному выражению <see cref="RegexHelper.VatinPattern"/></item>
        /// </list>
        [RegularExpression(RegexHelper.VatinPattern, ErrorMessageResourceType = typeof(ErrorStrings),
            ErrorMessageResourceName = "StringFormatError")]
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "ИНН организации-пользователя")]
        public string Vatin { get; }

        /// <summary>
        /// E-mail организации (адрес отравителя электронных чеков)
        /// </summary>
        /// <list type="bullet">
        /// <item>Должно соответствовать регулярному выражению <see cref="RegexHelper.EmailAddressPattern"/></item>
        /// </list>
        [RegularExpression(RegexHelper.EmailAddressPattern,
            ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "StringFormatError")]
        [Display(Name = "E-mail организации (адрес отравителя электронных чеков)")]
        public string Email { get; set; }

        /// <summary>
        /// Адрес расчетов
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Адрес расчетов")]
        public string Address { get; }

        /// <summary>
        /// Список систем налогообложения
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// <item>Минимальное кол-во элементов: 1</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        [MinLength(1, ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "MinLengthError")]
        [Display(Name = "Список систем налогообложения")]
        public ISet<TaxationType> TaxationTypes { get; }

        /// <summary>
        /// Признак агента
        /// </summary>
        [Display(Name = "Признак агента")]
        public ISet<AgentType> Agents { get; set; }
    }
}