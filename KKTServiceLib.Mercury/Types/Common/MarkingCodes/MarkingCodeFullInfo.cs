#region

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using CoreLib.CORE.Helpers.ObjectHelpers;
using CoreLib.CORE.Helpers.StringHelpers;
using CoreLib.CORE.Helpers.ValidationHelpers.Attributes;
using CoreLib.CORE.Resources;
using KKTServiceLib.Mercury.Types.Enums;

#endregion

namespace KKTServiceLib.Mercury.Types.Common.MarkingCodes
{
    [Description("Информация о маркированном товаре")]
    public class MarkingCodeFullInfo
    {
        /// <summary>
        /// Информация о маркированном товаре
        /// </summary>
        /// <param name="imc">Base64-представление значения кода маркировки</param>
        public MarkingCodeFullInfo(string imc)
        {
            if (imc.IsNullOrEmptyOrWhiteSpace() || !Regex.IsMatch(imc, RegexExtensions.Base64Pattern))
            {
                throw new ArgumentException(
                    string.Format(ValidationStrings.ResourceManager.GetString("StringFormatError"),
                        GetType().GetProperty(nameof(Mc)).GetPropertyDisplayName()),
                    nameof(imc));
            }

            Mc = imc;
        }

        /// <summary>
        /// Base64-представление значения кода маркировки
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// <item>Должно соответствовать регулярному выражению <see cref="RegexExtensions.Base64Pattern"/></item>
        /// </list>
        [Display(Name = "base64-представление значения кода маркировки")]
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [RegularExpression(RegexExtensions.Base64Pattern, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringFormatError")]
        public string Mc { get; }

        /// <summary>
        /// Штриховой код формата EAN-8 или EAN-13
        /// </summary>
        /// <remarks>
        /// Передаётся только для подакцизной алкогольной продукции
        /// </remarks>
        [Display(Name = "Штриховой код формата EAN-8 или EAN-13")]
        [RegularExpression(RegexExtensions.BarcodeEAN8Pattern + "|" + RegexExtensions.BarcodeEAN13Pattern,
            ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringFormatError")]
        public string Ean { get; set; }

        /// <summary>
        /// Режим обработки кода товара (в ФФД 1.2 допустима передача только значения 0)
        /// </summary>
        /// <remarks>
        /// Значение по умолчанию: 0
        /// </remarks>
        [Display(Name = "Режим обработки кода товара")]
        public int? ProcessingMode { get; set; } = 0;

        /// <summary>
        /// Планируемый статус КМ
        /// </summary>
        [Display(Name = "Планируемый статус КМ")]
        public ItemEstimatedStatus? PlannedStatus { get; set; }

        /// <summary>
        /// Дробное количество маркированного товара, выраженное в виде правильной дроби
        /// </summary>
        [Display(Name = "Дробное количество маркированного товара, выраженное в виде правильной дроби")]
        [ComplexObjectValidation(ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "ComplexObjectValidationError")]
        public FractionalNumber Part { get; set; }
    }
}