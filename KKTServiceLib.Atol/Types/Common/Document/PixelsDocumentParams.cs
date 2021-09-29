using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using KKTServiceLib.Atol.Types.Enums;
using KKTServiceLib.Atol.Types.Interfaces;
using KKTServiceLib.Shared.Helpers;
using KKTServiceLib.Shared.Resources;

namespace KKTServiceLib.Atol.Types.Common.Document
{
    [Description("Картинка (массив пикселей)")]
    public class PixelsDocumentParams : DocumentParams, ICommonDocumentElement
    {
        /// <summary>
        /// Картинка (массив пикселей)
        /// </summary>
        /// <param name="pixels">Массив пикселей в base64</param>
        /// <param name="width">Ширина картинки в пикселях</param>
        public PixelsDocumentParams(string pixels, int width) : base(PrintDocumentType.Pixels)
        {
            if (pixels.IsNullOrEmptyOrWhiteSpace() || !Regex.IsMatch(pixels, RegexHelper.Base64Pattern))
            {
                throw new ArgumentException(
                    string.Format(ErrorStrings.ResourceManager.GetString("StringFormatError"),
                        GetType().GetProperty(nameof(Pixels)).GetDisplayName()),
                    nameof(pixels));
            }

            if (width <= 0 || pixels.Length % width != 0)
            {
                throw new ArgumentException(
                    string.Format(ErrorStrings.ResourceManager.GetString("DigitRangeValuesError"),
                        GetType().GetProperty(nameof(Width)).GetDisplayName(), 1, int.MaxValue),
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
        /// <item>Должно соответствовать регулярному выражению <see cref="RegexHelper.Base64Pattern"/></item>
        /// </list>
        [Display(Name = "Массив пикселей в base64")]
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        [RegularExpression(RegexHelper.Base64Pattern, ErrorMessageResourceType = typeof(ErrorStrings),
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
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(ErrorStrings),
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
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(ErrorStrings),
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