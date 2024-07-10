#region

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using CoreLib.CORE.Helpers.ObjectHelpers;
using CoreLib.CORE.Helpers.StringHelpers;
using CoreLib.CORE.Resources;
using KKTServiceLib.Atol.Types.Enums;
using KKTServiceLib.Atol.Types.Interfaces;

#endregion

namespace KKTServiceLib.Atol.Types.Common.Document
{
    [Description("Картинка (массив пикселей)")]
    public class PixelsDocumentParams: DocumentParams, ICommonDocumentElement
    {
        /// <summary>
        /// Картинка (массив пикселей)
        /// </summary>
        /// <param name="pixels">Массив пикселей в base64</param>
        /// <param name="width">Ширина картинки в пикселях</param>
        public PixelsDocumentParams(string pixels, int width): base(PrintDocumentType.Pixels)
        {
            if (pixels.IsNullOrEmptyOrWhiteSpace() || !Regex.IsMatch(pixels, RegexExtensions.Base64Pattern))
            {
                throw new ArgumentException(
                    string.Format(ValidationStrings.ResourceManager.GetString("StringFormatError"),
                        GetType().GetProperty(nameof(Pixels)).GetPropertyDisplayName()),
                    nameof(pixels));
            }

            if (width <= 0 || pixels.Length % width != 0)
            {
                throw new ArgumentException(
                    string.Format(ValidationStrings.ResourceManager.GetString("DigitRangeValuesError"),
                        GetType().GetProperty(nameof(Width)).GetPropertyDisplayName(), 1, int.MaxValue),
                    nameof(width));
            }

            Pixels = pixels;
            Width = width;
        }

        /// <summary>
        /// Массив пикселей в base64
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// <item>Должно соответствовать регулярному выражению <see cref="RegexExtensions.Base64Pattern"/></item>
        /// </list>
        [Display(Name = "Массив пикселей в base64")]
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [RegularExpression(RegexExtensions.Base64Pattern, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringFormatError")]
        public string Pixels { get; }

        /// <summary>
        /// Ширина картинки в пикселях
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// <item>Должно лежать в диапазоне: 1-<see cref="int.MaxValue"/></item>
        /// </list>
        /// <remarks>
        /// Размер массива пикселей должен быть кратен этому значению
        /// </remarks>
        [Display(Name = "Ширина картинки в пикселях")]
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "DigitRangeValuesError")]
        public int Width { get; }

        /// <summary>
        /// Процент увеличения картинки
        /// </summary>
        /// <list type="bullet">
        /// <item>Должно лежать в диапазоне: 1-<see cref="int.MaxValue"/></item>
        /// </list>
        /// <remarks>
        /// Значение по умолчанию: 100
        /// </remarks>
        [Display(Name = "Процент увеличения картинки")]
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "DigitRangeValuesError")]
        public int Scale { get; set; } = 100;

        /// <summary>
        /// Выравнивание
        /// </summary>
        /// <remarks>
        /// Значение по умолчанию: <see cref="AlignmentType.Center"/>
        /// </remarks>
        [Display(Name = "Выравнивание")]
        public AlignmentType Alignment { get; set; } = AlignmentType.Center;
    }
}