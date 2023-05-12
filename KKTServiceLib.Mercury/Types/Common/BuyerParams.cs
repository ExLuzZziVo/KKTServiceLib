using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using KKTServiceLib.Mercury.Types.Enums;
using KKTServiceLib.Shared.Helpers;
using KKTServiceLib.Shared.Resources;
using KKTServiceLib.Shared.Types.Converters;
using Newtonsoft.Json;

namespace KKTServiceLib.Mercury.Types.Common
{
    [Description("Информация о покупателе")]
    public class BuyerParams
    {
        /// <summary>
        /// Информация о покупателе
        /// </summary>
        /// <param name="name">Наименование</param>
        /// <param name="vatin">ИНН</param>
        public BuyerParams(string name, string vatin)
        {
            if (name.IsNullOrEmptyOrWhiteSpace())
            {
                throw new ArgumentException(
                    string.Format(
                        ErrorStrings.ResourceManager.GetString("StringFormatError"),
                        GetType().GetProperty(nameof(BuyerName)).GetDisplayName()),
                    nameof(name));
            }

            if (vatin.IsNullOrEmptyOrWhiteSpace() || !Regex.IsMatch(vatin, RegexHelper.VatinPattern))
            {
                throw new ArgumentException(
                    string.Format(
                        ErrorStrings.ResourceManager.GetString("StringFormatError"),
                        GetType().GetProperty(nameof(BuyerINN)).GetDisplayName()),
                    nameof(vatin));
            }

            BuyerName = name;
            BuyerINN = vatin;
        }

        /// <summary>
        /// Наименование покупателя
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Наименование покупателя")]
        public string BuyerName { get; }

        /// <summary>
        /// ИНН покупателя
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// <item>Должно соответствовать регулярному выражению <see cref="RegexHelper.VatinPattern"/></item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "ИНН покупателя")]
        [RegularExpression(RegexHelper.VatinPattern, ErrorMessageResourceType = typeof(ErrorStrings),
            ErrorMessageResourceName = "StringFormatError")]
        public string BuyerINN { get; }
        
        /// <summary>
        /// Дата рождения
        /// </summary>
        /// <remarks>
        /// Только для ФФД ≥ 1.2
        /// </remarks>
        [Display(Name = "Дата рождения")]
        [JsonConverter(typeof(CustomDateTimeConverter), "yyyy-MM-dd")]
        public DateTime? Birthday { get; set; }

        /// <summary>
        /// Гражданство
        /// </summary>
        /// <list type="bullet">
        /// <item>Должно соответствовать регулярному выражению <see cref="RegexHelper.CountryOfOriginCodePattern"/></item>
        /// <item>Максимальная длина: 3</item>
        /// </list>
        /// <remarks>
        /// Только для ФФД ≥ 1.2
        /// </remarks>
        [Display(Name = "Гражданство")]
        [MaxLength(3, ErrorMessageResourceType = typeof(ErrorStrings),
            ErrorMessageResourceName = "StringMaxLengthError")]
        [RegularExpression(RegexHelper.CountryOfOriginCodePattern, ErrorMessageResourceType = typeof(ErrorStrings),
            ErrorMessageResourceName = "StringFormatError")]
        public string Citizenship { get; set; }

        /// <summary>
        /// Код вида документа, удостоверяющего личность
        /// </summary>
        /// <remarks>
        /// Только для ФФД ≥ 1.2
        /// </remarks>
        [Display(Name = "Код вида документа, удостоверяющего личность")]
        public IdentityDocumentType? DocType { get; set; }

        /// <summary>
        /// Данные документа, удостоверяющего личность
        /// </summary>
        /// <list type="bullet">
        /// <item>Максимальная длина: 64</item>
        /// </list>
        /// <remarks>
        /// Только для ФФД ≥ 1.2
        /// </remarks>
        [Display(Name = "Данные документа, удостоверяющего личность")]
        [MaxLength(64, ErrorMessageResourceType = typeof(ErrorStrings),
            ErrorMessageResourceName = "StringMaxLengthError")]
        public string DocData { get; set; }

        /// <summary>
        /// Адрес покупателя/клиента
        /// </summary>
        /// <list type="bullet">
        /// <item>Максимальная длина: 256</item>
        /// </list>
        /// <remarks>
        /// Только для ФФД ≥ 1.2
        /// </remarks>
        [Display(Name = "Адрес покупателя/клиента")]
        [MaxLength(256, ErrorMessageResourceType = typeof(ErrorStrings),
            ErrorMessageResourceName = "StringMaxLengthError")]
        public string Address { get; set; }
    }
}