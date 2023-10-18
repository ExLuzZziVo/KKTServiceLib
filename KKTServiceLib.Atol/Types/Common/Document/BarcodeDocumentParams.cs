#region

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using CoreLib.CORE.Helpers.EnumHelpers;
using CoreLib.CORE.Helpers.ObjectHelpers;
using CoreLib.CORE.Helpers.StringHelpers;
using CoreLib.CORE.Helpers.ValidationHelpers.Attributes;
using CoreLib.CORE.Resources;
using KKTServiceLib.Atol.Types.Enums;
using KKTServiceLib.Atol.Types.Interfaces;
using KKTServiceLib.Shared.Resources;

#endregion

namespace KKTServiceLib.Atol.Types.Common.Document
{
    [Description("Элемент штрихкода")]
    public class BarcodeDocumentParams : DocumentParams, ICommonDocumentElement
    {
        /// <summary>
        /// Элемент штрихкода
        /// </summary>
        /// <param name="barcodeValue">Данные ШК</param>
        /// <param name="barcodeType">Тип ШК</param>
        public BarcodeDocumentParams(string barcodeValue, BarcodeType barcodeType) : base(PrintDocumentType.Barcode)
        {
            if (barcodeValue.IsNullOrEmptyOrWhiteSpace())
            {
                throw new ArgumentException(
                    string.Format(ValidationStrings.ResourceManager.GetString("RequiredError"),
                        GetType().GetProperty(nameof(Barcode)).GetPropertyDisplayName()),
                    nameof(barcodeValue));
            }

            var isBarcodeValueValid = false;

            switch (barcodeType)
            {
                case BarcodeType.EAN8:
                    if (Regex.IsMatch(barcodeValue, RegexExtensions.BarcodeEAN8Pattern))
                    {
                        isBarcodeValueValid = true;
                    }

                    break;
                case BarcodeType.EAN13:
                    if (Regex.IsMatch(barcodeValue, RegexExtensions.BarcodeEAN13Pattern))
                    {
                        isBarcodeValueValid = true;
                    }

                    break;
                case BarcodeType.CODE39:
                    if (Regex.IsMatch(barcodeValue, RegexExtensions.BarcodeCODE39Pattern))
                    {
                        isBarcodeValueValid = true;
                    }

                    break;
                case BarcodeType.QR:
                    if (barcodeValue.Length < 7089)
                    {
                        isBarcodeValueValid = true;
                    }

                    break;
                case BarcodeType.UPCA:
                    if (Regex.IsMatch(barcodeValue, RegexExtensions.BarcodeUPCAPattern))
                    {
                        isBarcodeValueValid = true;
                    }

                    break;
                case BarcodeType.UPCE:
                    if (Regex.IsMatch(barcodeValue, RegexExtensions.BarcodeUPCEPattern))
                    {
                        isBarcodeValueValid = true;
                    }

                    break;
                case BarcodeType.CODE93:
                    if (Regex.IsMatch(barcodeValue, RegexExtensions.BarcodeCODE93Pattern))
                    {
                        isBarcodeValueValid = true;
                    }

                    break;
                case BarcodeType.CODE128:
                    if (Regex.IsMatch(barcodeValue, RegexExtensions.BarcodeCODE128Pattern))
                    {
                        isBarcodeValueValid = true;
                    }

                    break;
                case BarcodeType.CODABAR:
                    if (Regex.IsMatch(barcodeValue, RegexExtensions.BarcodeCODABARPattern))
                    {
                        isBarcodeValueValid = true;
                    }

                    break;
                case BarcodeType.ITF:
                    if (Regex.IsMatch(barcodeValue, RegexExtensions.BarcodeITFPattern))
                    {
                        isBarcodeValueValid = true;
                    }

                    break;
                case BarcodeType.ITF14:
                    if (Regex.IsMatch(barcodeValue, RegexExtensions.BarcodeITF14Pattern))
                    {
                        isBarcodeValueValid = true;
                    }

                    break;
                case BarcodeType.GS1_128:
                    if (Regex.IsMatch(barcodeValue, RegexExtensions.BarcodeGS1_128Pattern))
                    {
                        isBarcodeValueValid = true;
                    }

                    break;
                case BarcodeType.PDF417:
                    if (Regex.IsMatch(barcodeValue, RegexExtensions.BarcodePDF417Pattern))
                    {
                        isBarcodeValueValid = true;
                    }

                    break;
                case BarcodeType.CODE39_EXTENDED:
                    if (Regex.IsMatch(barcodeValue, RegexExtensions.BarcodeCODE39_EXTENDEDPattern))
                    {
                        isBarcodeValueValid = true;
                    }

                    break;
            }

            if (!isBarcodeValueValid)
            {
                throw new ArgumentException(
                    string.Format(ErrorStrings.ResourceManager.GetString("BarcodeValueFormatError"),
                        barcodeType.GetDisplayName()), nameof(barcodeValue));
            }

            Barcode = barcodeValue;
            BarcodeType = barcodeType;
        }

        /// <summary>
        /// Данные ШК
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Данные ШК")]
        public string Barcode { get; }

        /// <summary>
        /// Тип ШК
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Тип ШК")]
        public BarcodeType BarcodeType { get; }

        /// <summary>
        /// Коэффициент увеличения
        /// </summary>
        /// <remarks>
        /// Значение по умолчанию: 1
        /// </remarks>
        [Display(Name = "Коэффициент увеличения")]
        public byte Scale { get; set; } = 1;

        /// <summary>
        /// Высота (только для одномерных ШК)
        /// </summary>
        /// <remarks>
        /// Значение по умолчанию: 30
        /// </remarks>
        [Display(Name = "Высота (только для одномерных ШК)")]
        public byte Height { get; set; } = 30;

        /// <summary>
        /// Печатать значение ШК (только для одномерных ШК)
        /// </summary>
        [Display(Name = "Печатать значение ШК (только для одномерных ШК)")]
        public bool PrintText { get; set; }

        /// <summary>
        /// Текст для печати рядом с ШК
        /// </summary>
        [ComplexObjectCollectionValidation(AllowNullItems = false, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "ComplexObjectCollectionValidationError")]
        [Display(Name = "Текст для печати рядом с ШК")]
        public TextDocumentParams[] Overlay { get; set; }

        /// <summary>
        /// Сохранять в электронном журнале (только для QR-кода)
        /// </summary>
        /// <remarks>
        /// Значение по умолчанию: true
        /// </remarks>
        [Display(Name = "Сохранять в электронном журнале (только для QR-кода)")]
        public bool StoreInJournal { get; set; } = true;

        /// <summary>
        /// Выравнивание
        /// </summary>
        [Display(Name = "Выравнивание")]
        public AlignmentType Alignment { get; set; }
    }
}