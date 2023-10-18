#region

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using CoreLib.CORE.Helpers.EnumHelpers;
using CoreLib.CORE.Helpers.ObjectHelpers;
using CoreLib.CORE.Helpers.StringHelpers;
using CoreLib.CORE.Resources;
using KKTServiceLib.Mercury.Types.Enums;
using KKTServiceLib.Shared.Resources;

#endregion

namespace KKTServiceLib.Mercury.Types.Operations.NonFiscal.PrintBarcode
{
    [Description("Печать штрихового кода")]
    public class PrintBarcodeOperation : Operation<PrintBarcodeResult>
    {
        /// <summary>
        /// Печать штрихового кода
        /// </summary>
        /// <param name="barcodeValue">Данные ШК</param>
        /// <param name="barcodeType">Тип ШК</param>
        public PrintBarcodeOperation(string barcodeValue, BarcodeType barcodeType) : base("PrintBarCode")
        {
            if (barcodeValue.IsNullOrEmptyOrWhiteSpace())
            {
                throw new ArgumentException(
                    string.Format(
                        ValidationStrings.ResourceManager.GetString("StringFormatError"),
                        GetType().GetProperty(nameof(Value)).GetPropertyDisplayName()),
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
                    if (barcodeValue.Length < 256)
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

            BcType = barcodeType;
            Value = barcodeValue;
        }

        /// <summary>
        /// Тип ШК
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Тип ШК")]
        public BarcodeType BcType { get; }

        /// <summary>
        /// Данные ШК
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Данные ШК")]
        public string Value { get; }
    }
}