using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using KKTServiceLib.Shared.Helpers;
using KKTServiceLib.Shared.Resources;
using KKTServiceLib.Shared.Types.Converters;
using Newtonsoft.Json;

namespace KKTServiceLib.Atol.Types.Common
{
    [Description("Отраслевой реквизит")]
    public class IndustryRequisiteParams
    {
        /// <summary>
        /// Дата документа основания
        /// </summary>
        [Display(Name = "Дата документа основания")]
        [JsonConverter(typeof(CustomDateTimeConverter), "yyyy.MM.dd")]
        public DateTime? Date { get; set; }

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
        public string Fois { get; set; }

        /// <summary>
        /// Номер документа основания
        /// </summary>
        [Display(Name = "Номер документа основания")]
        public string Number { get; set; }

        /// <summary>
        /// Значение отраслевого реквизита
        /// </summary>
        [Display(Name = "Значение отраслевого реквизита")]
        public string IndustryAttribute { get; set; }
    }
}