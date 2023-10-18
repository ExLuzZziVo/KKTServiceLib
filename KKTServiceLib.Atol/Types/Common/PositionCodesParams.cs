#region

using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using CoreLib.CORE.Helpers.StringHelpers;
using CoreLib.CORE.Resources;
using KKTServiceLib.Shared.Helpers;

#endregion

namespace KKTServiceLib.Atol.Types.Common
{
    [Description("Коды товара")]
    public class PositionCodesParams
    {
        /// <summary>
        /// Нераспознанный код товара
        /// </summary>
        [Display(Name = "Нераспознанный код товара")]
        public string Undefined { get; set; }

        /// <summary>
        /// КТ EAN-8
        /// </summary>
        /// <list type="bullet">
        /// <item>Должно соответствовать регулярному выражению <see cref="RegexExtensions.BarcodeEAN8Pattern"/></item>
        /// </list>
        [Display(Name = "КТ EAN-8")]
        [RegularExpression(RegexExtensions.BarcodeEAN8Pattern, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringFormatError")]
        public string Ean8 { get; set; }

        /// <summary>
        /// КТ EAN-13
        /// </summary>
        /// <list type="bullet">
        /// <item>Должно соответствовать регулярному выражению <see cref="RegexExtensions.BarcodeEAN13Pattern"/></item>
        /// </list>
        [Display(Name = "КТ EAN-13")]
        [RegularExpression(RegexExtensions.BarcodeEAN13Pattern, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringFormatError")]
        public string Ean13 { get; set; }

        /// <summary>
        /// КТ ITF-14
        /// </summary>
        /// <list type="bullet">
        /// <item>Должно соответствовать регулярному выражению <see cref="RegexExtensions.BarcodeITF14Pattern"/></item>
        /// </list>
        [Display(Name = "КТ ITF-14")]
        [RegularExpression(RegexExtensions.BarcodeITF14Pattern, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringFormatError")]
        public string Itf14 { get; set; }

        /// <summary>
        /// КТ GS1.0
        /// </summary>
        /// <list type="bullet">
        /// <item>Должно соответствовать регулярному выражению <see cref="RegexHelper.BarcodeTags1304_1306Pattern"/></item>
        /// </list>
        [Display(Name = "КТ GS1.0")]
        [RegularExpression(RegexHelper.BarcodeTags1304_1306Pattern,
            ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringFormatError")]
        public string Gs10 { get; set; }

        /// <summary>
        /// КТ GS1.M
        /// </summary>
        /// <list type="bullet">
        /// <item>Должно соответствовать регулярному выражению <see cref="RegexHelper.BarcodeTags1304_1306Pattern"/></item>
        /// </list>
        [Display(Name = "КТ GS1.M")]
        [RegularExpression(RegexHelper.BarcodeTags1304_1306Pattern,
            ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringFormatError")]
        public string Gs1m { get; set; }

        /// <summary>
        /// КТ КМК
        /// </summary>
        /// <list type="bullet">
        /// <item>Должно соответствовать регулярному выражению <see cref="RegexHelper.BarcodeTags1304_1306Pattern"/></item>
        /// </list>
        [Display(Name = "КТ КМК")]
        [RegularExpression(RegexHelper.BarcodeTags1304_1306Pattern,
            ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringFormatError")]
        public string Short { get; set; }

        /// <summary>
        /// КТ МИ
        /// </summary>
        /// <list type="bullet">
        /// <item>Должно соответствовать регулярному выражению <see cref="RegexExtensions_Ru.BarcodeFurPattern"/></item>
        /// </list>
        [Display(Name = "КТ МИ")]
        [RegularExpression(RegexExtensions_Ru.BarcodeFurPattern, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringFormatError")]
        public string Furs { get; set; }

        /// <summary>
        /// КТ ЕГАИС-2.0
        /// </summary>
        /// <list type="bullet">
        /// <item>Должно соответствовать регулярному выражению <see cref="RegexHelper.BarcodeTag1308Pattern"/></item>
        /// </list>
        [Display(Name = "КТ ЕГАИС-2.0")]
        [RegularExpression(RegexHelper.BarcodeTag1308Pattern, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringFormatError")]
        public string Egais20 { get; set; }

        /// <summary>
        /// КТ ЕГАИС-3.0
        /// </summary>
        /// <list type="bullet">
        /// <item>Должно соответствовать регулярному выражению <see cref="RegexHelper.BarcodeTag1309Pattern"/></item>
        /// </list>
        [Display(Name = "КТ ЕГАИС-3.0")]
        [RegularExpression(RegexHelper.BarcodeTag1309Pattern, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringFormatError")]
        public string Egais30 { get; set; }

        /// <summary>
        /// КТ Ф.1
        /// </summary>
        [Display(Name = "КТ Ф.1")]
        public string F1 { get; set; }

        /// <summary>
        /// КТ Ф.2
        /// </summary>
        [Display(Name = "КТ Ф.2")]
        public string F2 { get; set; }

        /// <summary>
        /// КТ Ф.3
        /// </summary>
        [Display(Name = "КТ Ф.3")]
        public string F3 { get; set; }

        /// <summary>
        /// КТ Ф.4
        /// </summary>
        [Display(Name = "КТ Ф.4")]
        public string F4 { get; set; }

        /// <summary>
        /// КТ Ф.5
        /// </summary>
        [Display(Name = "КТ Ф.5")]
        public string F5 { get; set; }

        /// <summary>
        /// КТ Ф.6
        /// </summary>
        [Display(Name = "КТ Ф.6")]
        public string F6 { get; set; }

        /// <summary>
        /// Массив кодов товаров
        /// </summary>
        [Display(Name = "Массив кодов товаров")]
        public ISet<string> Codes { get; set; }
    }
}