#region

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using CoreLib.CORE.Helpers.ObjectHelpers;
using CoreLib.CORE.Helpers.StringHelpers;
using CoreLib.CORE.Resources;

#endregion

namespace KKTServiceLib.Mercury.Types.Common
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
                        ValidationStrings.ResourceManager.GetString("StringFormatError"),
                        GetType().GetProperty(nameof(Name)).GetPropertyDisplayName()),
                    nameof(name));
            }

            if (vatin.IsNullOrEmptyOrWhiteSpace() || !Regex.IsMatch(vatin, RegexExtensions_Ru.VatinPattern))
            {
                throw new ArgumentException(
                    string.Format(
                        ValidationStrings.ResourceManager.GetString("StringFormatError"),
                        GetType().GetProperty(nameof(Inn)).GetPropertyDisplayName()),
                    nameof(vatin));
            }

            Name = name;
            Inn = vatin;
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
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "ИНН организации-пользователя")]
        [RegularExpression(RegexExtensions_Ru.VatinPattern, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringFormatError")]
        public string Inn { get; }
    }
}