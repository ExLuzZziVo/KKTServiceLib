#region

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using CoreLib.CORE.Helpers.ObjectHelpers;
using CoreLib.CORE.Helpers.StringHelpers;
using CoreLib.CORE.Resources;
using KKTServiceLib.Shared.Helpers;

#endregion

namespace KKTServiceLib.Atol.Types.Common
{
    [Description("Параметры ОФД")]
    public class OfdParams
    {
        /// <summary>
        /// Параметры ОФД
        /// </summary>
        /// <param name="name">Название ОФД</param>
        /// <param name="vatin">ИНН ОФД</param>
        /// <param name="host">Адрес сервера ОФД</param>
        /// <param name="port">Порт сервера ОФД</param>
        /// <param name="dns">DNS сервера ОФД</param>
        public OfdParams(string name, string vatin, string host, ushort port, string dns)
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
                        GetType().GetProperty(nameof(Vatin)).GetPropertyDisplayName()),
                    nameof(vatin));
            }

            if (host.IsNullOrEmptyOrWhiteSpace() || !Regex.IsMatch(host, RegexHelper.IPAddressOrUrlPattern))
            {
                throw new ArgumentException(
                    string.Format(
                        ValidationStrings.ResourceManager.GetString("StringFormatError"),
                        GetType().GetProperty(nameof(Host)).GetPropertyDisplayName()),
                    nameof(host));
            }

            if (dns.IsNullOrEmptyOrWhiteSpace() || !Regex.IsMatch(dns, RegexExtensions.IpAddressPattern))
            {
                throw new ArgumentException(
                    string.Format(
                        ValidationStrings.ResourceManager.GetString("StringFormatError"),
                        GetType().GetProperty(nameof(Dns)).GetPropertyDisplayName()),
                    nameof(dns));
            }

            Name = name;
            Vatin = vatin;
            Host = host;
            Port = port;
            Dns = dns;
        }

        [JsonConstructor]
        private OfdParams() { }

        /// <summary>
        /// Название ОФД
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Название ОФД")]
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
        public string Vatin { get; }

        /// <summary>
        /// Адрес сервера ОФД
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// <item>Должно соответствовать регулярному выражению <see cref="RegexHelper.IPAddressOrUrlPattern"/></item>
        /// </list>
        [RegularExpression(
            RegexHelper.IPAddressOrUrlPattern,
            ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "StringFormatError")]
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Адрес сервера ОФД")]
        public string Host { get; }

        /// <summary>
        /// Порт сервера ОФД
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Порт сервера ОФД")]
        public ushort Port { get; }

        /// <summary>
        /// DNS сервера ОФД
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// <item>Должно соответствовать регулярному выражению <see cref="RegexExtensions.IpAddressPattern"/></item>
        /// </list>
        [RegularExpression(RegexExtensions.IpAddressPattern,
            ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "StringFormatError")]
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "DNS сервера ОФД")]
        public string Dns { get; }
    }
}