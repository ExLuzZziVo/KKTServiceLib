#region

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using CoreLib.CORE.Helpers.Converters;
using CoreLib.CORE.Resources;
using KKTServiceLib.Shared.Helpers;

#endregion

namespace KKTServiceLib.Mercury.Types.Common
{
    [Description("Отраслевой реквизит")]
    [JsonDerivedType(typeof(IndustryRequisiteReceiptParams))]
    public class IndustryRequisiteParams
    {
        /// <summary>
        /// Дата документа основания
        /// </summary>
        [Display(Name = "Дата документа основания")]
        [CustomDateTimeConverter("yyyy-MM-dd")]
        public DateTime? DocDate { get; set; }

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
        public virtual string Value { get; set; }
    }
}