#region

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using KKTServiceLib.Shared.Helpers;
using KKTServiceLib.Shared.Resources;
using Newtonsoft.Json;

#endregion

namespace AtolKKTServiceLib.Types.Common
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
                        ErrorStrings.ResourceManager.GetString("StringFormatError"),
                        this.GetType().GetProperty(nameof(Name)).GetDisplayName()),
                    nameof(name));
            }

            if (vatin.IsNullOrEmptyOrWhiteSpace() || !Regex.IsMatch(vatin, RegexHelper.EntityVatinPattern))
            {
                throw new ArgumentException(
                    string.Format(
                        ErrorStrings.ResourceManager.GetString("StringFormatError"),
                        this.GetType().GetProperty(nameof(Vatin)).GetDisplayName()),
                    nameof(vatin));
            }

            if (host.IsNullOrEmptyOrWhiteSpace() || !Regex.IsMatch(host, RegexHelper.UrlPattern))
            {
                throw new ArgumentException(
                    string.Format(
                        ErrorStrings.ResourceManager.GetString("StringFormatError"),
                        this.GetType().GetProperty(nameof(Host)).GetDisplayName()),
                    nameof(host));
            }

            if (dns.IsNullOrEmptyOrWhiteSpace() || !Regex.IsMatch(dns, RegexHelper.IPAddressPattern))
            {
                throw new ArgumentException(
                    string.Format(
                        ErrorStrings.ResourceManager.GetString("StringFormatError"),
                        this.GetType().GetProperty(nameof(Dns)).GetDisplayName()),
                    nameof(dns));
            }

            Name = name;
            Vatin = vatin;
            Host = host;
            Port = port;
            Dns = dns;
        }

        [JsonConstructor]
        private OfdParams()
        {
        }

        /// <summary>
        /// Название ОФД
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Название ОФД")]
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
        public string Vatin { get; }

        /// <summary>
        /// Адрес сервера ОФД
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// <item>Должно соответствовать регулярному выражению <see cref="RegexHelper.UrlPattern"/></item>
        /// </list>
        [RegularExpression(
            RegexHelper.UrlPattern,
            ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "StringFormatError")]
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Адрес сервера ОФД")]
        public string Host { get; }

        /// <summary>
        /// Порт сервера ОФД
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Порт сервера ОФД")]
        public ushort Port { get; }

        /// <summary>
        /// DNS сервера ОФД
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// <item>Должно соответствовать регулярному выражению <see cref="RegexHelper.IPAddressPattern"/></item>
        /// </list>
        [RegularExpression(RegexHelper.IPAddressPattern,
            ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "StringFormatError")]
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "DNS сервера ОФД")]
        public string Dns { get; }
    }
}