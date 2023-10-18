#region

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using CoreLib.CORE.Helpers.Converters;
using CoreLib.CORE.Resources;
using KKTServiceLib.Shared.Helpers;

#endregion

namespace KKTServiceLib.Atol.Types.Common
{
    [Description("Отраслевой реквизит")]
    public class IndustryRequisiteParams
    {
        /// <summary>
        /// Дата документа основания
        /// </summary>
        [Display(Name = "Дата документа основания")]
        [CustomDateTimeConverter("yyyy.MM.dd")]
        public DateTime? Date { get; set; }

        /// <summary>
        /// Идентификатор ФОИВ
        /// </summary>
        /// <list type="bullet">
        /// <item>Должно соответствовать регулярному выражению <see cref="RegexHelper.CountryOfOriginCodePattern"/></item>
        /// <item>Максимальная длина: 3</item>
        /// </list>
        [Display(Name = "Идентификатор ФОИВ")]
        [MaxLength(3, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringMaxLengthError")]
        [RegularExpression(RegexHelper.CountryOfOriginCodePattern, ErrorMessageResourceType = typeof(ValidationStrings),
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