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
    [Description("Параметры ОФД")]
    public class OfdParams
    {
        /// <summary>
        /// Параметры ОФД
        /// </summary>
        /// <param name="name">Наименование</param>
        /// <param name="vatin">ИНН</param>
        /// <param name="host">Адрес сервера</param>
        /// <param name="port">Порт сервера</param>
        public OfdParams(string name, string vatin, string host, ushort port)
        {
            if (name.IsNullOrEmptyOrWhiteSpace())
            {
                throw new ArgumentException(
                    string.Format(
                        ValidationStrings.ResourceManager.GetString("StringFormatError"),
                        GetType().GetProperty(nameof(Name)).GetPropertyDisplayName()),
                    nameof(name));
            }

            if (vatin.IsNullOrEmptyOrWhiteSpace() || !Regex.IsMatch(vatin, RegexExtensions_Ru.EntityVatinPattern))
            {
                throw new ArgumentException(
                    string.Format(
                        ValidationStrings.ResourceManager.GetString("StringFormatError"),
                        GetType().GetProperty(nameof(Inn)).GetPropertyDisplayName()),
                    nameof(vatin));
            }

            if (host.IsNullOrEmptyOrWhiteSpace() || !Regex.IsMatch(host, RegexExtensions.UrlPattern))
            {
                throw new ArgumentException(
                    string.Format(
                        ValidationStrings.ResourceManager.GetString("StringFormatError"),
                        GetType().GetProperty(nameof(Url)).GetPropertyDisplayName()),
                    nameof(host));
            }

            Name = name;
            Inn = vatin;
            Url = host;
            Port = port;
        }

        [JsonConstructor]
        private OfdParams() { }

        /// <summary>
        /// Наименование ОФД
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Наименование ОФД")]
        public string Name { get; }

        /// <summary>
        /// ИНН ОФД
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// <item>Должно соответствовать регулярному выражению <see cref="RegexExtensions_Ru.EntityVatinPattern"/></item>
        /// </list>
        [RegularExpression(RegexExtensions_Ru.EntityVatinPattern, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringFormatError")]
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "ИНН ОФД")]
        public string Inn { get; }

        /// <summary>
        /// Адрес сервера ОФД
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// <item>Должно соответствовать регулярному выражению <see cref="RegexExtensions.UrlPattern"/></item>
        /// </list>
        [RegularExpression(RegexExtensions.UrlPattern,
            ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "StringFormatError")]
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Адрес сервера ОФД")]
        public string Url { get; }

        /// <summary>
        /// Порт сервера ОФД
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Display(Name = "Порт сервера ОФД")]
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        public ushort Port { get; set; }
    }
}