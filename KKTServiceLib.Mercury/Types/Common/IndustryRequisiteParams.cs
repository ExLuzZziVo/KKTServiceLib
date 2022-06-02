using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using KKTServiceLib.Shared.Helpers;
using KKTServiceLib.Shared.Resources;
using KKTServiceLib.Shared.Types.Converters;
using Newtonsoft.Json;

namespace KKTServiceLib.Mercury.Types.Common
{
    [Description("Отраслевой реквизит")]
    public class IndustryRequisiteParams
    {
        /// <summary>
        /// Дата документа основания
        /// </summary>
        [Display(Name = "Дата документа основания")]
        [JsonConverter(typeof(CustomDateTimeConverter), "yyyy-MM-dd")]
        public DateTime? DocDate { get; set; }

        /// <summary>
        /// Идентификатор ФОИВ
        /// </summary>
        /// <list type="bullet">
        /// <item>Должно соответствовать регулярному выражению <see cref="RegexHelper.CountryOfOriginCodePattern"/></item>
        /// <item>Максимальная длина: 3</item>
        /// </list>
        [Display(Name = "Идентификатор ФОИВ")]
        [MaxLength(3, ErrorMessageResourceType = typeof(ErrorStrings),
            ErrorMessageResourceName = "StringMaxLengthError")]
        [RegularExpression(RegexHelper.CountryOfOriginCodePattern, ErrorMessageResourceType = typeof(ErrorStrings),
            ErrorMessageResourceName = "StringFormatError")]
        public string IdFOIV { get; set; }

        /// <summary>
        /// Номер документа основания
        /// </summary>
        [Display(Name = "Номер документа основания")]
        public string DocNum { get; set; }

        /// <summary>
        /// Значение отраслевого реквизита
        /// </summary>
        [Display(Name = "Значение отраслевого реквизита")]
        public string Value { get; set; }
    }
}