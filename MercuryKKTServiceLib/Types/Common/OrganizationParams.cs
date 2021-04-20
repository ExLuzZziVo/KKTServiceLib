using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using KKTServiceLib.Shared.Helpers;
using KKTServiceLib.Shared.Resources;
using Newtonsoft.Json;

namespace MercuryKKTServiceLib.Types.Common
{
    [Description("Информация об организации-пользователе")]
    public class OrganizationParams
    {
        /// <summary>
        /// Информация об организации-пользователе
        /// </summary>
        /// <param name="name">Название</param>
        /// <param name="vatin">ИНН</param>
        public OrganizationParams(string name, string vatin)
        {
            if (name.IsNullOrEmptyOrWhiteSpace())
            {
                throw new ArgumentException(
                    string.Format(
                        ErrorStrings.ResourceManager.GetString("StringFormatError"),
                        this.GetType().GetProperty(nameof(Name)).GetDisplayName()),
                    nameof(name));
            }

            if (vatin.IsNullOrEmptyOrWhiteSpace() || !Regex.IsMatch(vatin, RegexHelper.VatinPattern))
            {
                throw new ArgumentException(
                    string.Format(
                        ErrorStrings.ResourceManager.GetString("StringFormatError"),
                        this.GetType().GetProperty(nameof(Inn)).GetDisplayName()),
                    nameof(vatin));
            }

            Name = name;
            Inn = vatin;
        }

        [JsonConstructor]
        private OrganizationParams()
        {
        }

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
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "ИНН организации-пользователя")]
        [RegularExpression(RegexHelper.VatinPattern, ErrorMessageResourceType = typeof(ErrorStrings),
            ErrorMessageResourceName = "StringFormatError")]
        public string Inn { get; }
    }
}