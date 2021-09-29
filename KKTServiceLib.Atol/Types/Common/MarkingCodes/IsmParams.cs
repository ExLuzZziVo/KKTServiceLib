using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using KKTServiceLib.Shared.Helpers;
using KKTServiceLib.Shared.Resources;
using Newtonsoft.Json;

namespace KKTServiceLib.Atol.Types.Common.MarkingCodes
{
    [Description("Параметры ИСМ")]
    public class IsmParams
    {
        /// <summary>
        /// Параметры ИСМ
        /// </summary>
        /// <param name="host">Адрес сервера ИСМ</param>
        /// <param name="port">Порт сервера ИСМ</param>
        public IsmParams(string host, ushort port)
        {
            if (host.IsNullOrEmptyOrWhiteSpace() || !Regex.IsMatch(host, RegexHelper.IPAddressOrUrlPattern))
            {
                throw new ArgumentException(
                    string.Format(
                        ErrorStrings.ResourceManager.GetString("StringFormatError"),
                        GetType().GetProperty(nameof(Host)).GetDisplayName()),
                    nameof(host));
            }

            Host = host;
            Port = port;
        }

        [JsonConstructor]
        private IsmParams() { }

        /// <summary>
        /// Адрес сервера ИСМ
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// <item>Должно соответствовать регулярному выражению <see cref="RegexHelper.IPAddressOrUrlPattern"/></item>
        /// </list>
        [Display(Name = "Адрес сервера ИСМ")]
        [RegularExpression(
            RegexHelper.IPAddressOrUrlPattern,
            ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "StringFormatError")]
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        public string Host { get; }

        /// <summary>
        /// Порт сервера ИСМ
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Display(Name = "Порт сервера ИСМ")]
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        public ushort Port { get; }
    }
}