using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using KKTServiceLib.Shared.Helpers;
using KKTServiceLib.Shared.Resources;
using Newtonsoft.Json;

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
                        ErrorStrings.ResourceManager.GetString("StringFormatError"),
                        this.GetType().GetProperty(nameof(Name)).GetDisplayName()),
                    nameof(name));
            }

            if (vatin.IsNullOrEmptyOrWhiteSpace() || !Regex.IsMatch(vatin, RegexHelper.EntityVatinPattern))
            {
                throw new ArgumentException(
                    string.Format(
                        ErrorStrings.ResourceManager.GetString("StringFormatError"),
                        this.GetType().GetProperty(nameof(Inn)).GetDisplayName()),
                    nameof(vatin));
            }

            if (host.IsNullOrEmptyOrWhiteSpace() || !Regex.IsMatch(host, RegexHelper.UrlPattern))
            {
                throw new ArgumentException(
                    string.Format(
                        ErrorStrings.ResourceManager.GetString("StringFormatError"),
                        this.GetType().GetProperty(nameof(Url)).GetDisplayName()),
                    nameof(host));
            }

            Name = name;
            Inn = vatin;
            Url = host;
            Port = port;
        }

        [JsonConstructor]
        private OfdParams()
        {
        }

        /// <summary>
        /// Наименование ОФД
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Наименование ОФД")]
        public string Name { get; }

        /// <summary>
        /// ИНН ОФД
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// <item>Должно соответствовать регулярному выражению <see cref="RegexHelper.EntityVatinPattern"/></item>
        /// </list>
        [RegularExpression(RegexHelper.EntityVatinPattern, ErrorMessageResourceType = typeof(ErrorStrings),
            ErrorMessageResourceName = "StringFormatError")]
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "ИНН ОФД")]
        public string Inn { get; }

        /// <summary>
        /// Адрес сервера ОФД
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// <item>Должно соответствовать регулярному выражению <see cref="RegexHelper.UrlPattern"/></item>
        /// </list>
        [RegularExpression(RegexHelper.UrlPattern,
            ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "StringFormatError")]
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Адрес сервера ОФД")]
        public string Url { get; }

        /// <summary>
        /// Порт сервера ОФД
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Display(Name = "Порт сервера ОФД")]
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        public ushort Port { get; set; }
    }
}