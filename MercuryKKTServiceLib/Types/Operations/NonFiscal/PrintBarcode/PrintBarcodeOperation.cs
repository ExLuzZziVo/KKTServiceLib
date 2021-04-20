using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using KKTServiceLib.Shared.Helpers;
using KKTServiceLib.Shared.Resources;
using MercuryKKTServiceLib.Types.Enums;

namespace MercuryKKTServiceLib.Types.Operations.NonFiscal.PrintBarcode
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
                        ErrorStrings.ResourceManager.GetString("StringFormatError"),
                        this.GetType().GetProperty(nameof(Value)).GetDisplayName()),
                    nameof(barcodeValue));
            }

            var isBarcodeValueValid = false;
            switch (barcodeType)
            {
                case BarcodeType.EAN8:
                    if (Regex.IsMatch(barcodeValue, RegexHelper.BarcodeEAN8Pattern))
                    {
                        isBarcodeValueValid = true;
                    }

                    break;
                case BarcodeType.EAN13:
                    if (Regex.IsMatch(barcodeValue, RegexHelper.BarcodeEAN13Pattern))
                    {
                        isBarcodeValueValid = true;
                    }

                    break;
                case BarcodeType.CODE39:
                    if (Regex.IsMatch(barcodeValue, RegexHelper.BarcodeCODE39Pattern))
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
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Тип ШК")]
        public BarcodeType BcType { get; }

        /// <summary>
        /// Данные ШК
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Данные ШК")]
        public string Value { get; }
    }
}