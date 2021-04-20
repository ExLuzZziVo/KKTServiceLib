using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using KKTServiceLib.Shared.Helpers;
using KKTServiceLib.Shared.Resources;

namespace MercuryKKTServiceLib.Types.Operations.NonFiscal.PrintEgaisSlip
{
    [Description("Печать слипа к чеку, содержащему АП")]
    public class PrintEgaisSlipOperation : Operation<PrintEgaisSlipResult>
    {
        /// <summary>
        /// Печать слипа к чеку, содержащему АП
        /// </summary>
        /// <param name="shiftNumber">Номер текущей кассовой смены</param>
        /// <param name="receiptNumber">Номер чека</param>
        /// <param name="kpp">КПП организации, продавшей алкогольную продукцию</param>
        /// <param name="url">Текст ссылки, полученной от УТМ при подписывании чека</param>
        /// <param name="sign">Отпечаток КЭП, полученный от УТМ при подписывании чека</param>
        public PrintEgaisSlipOperation(int shiftNumber, int receiptNumber, string kpp, string url, string sign) : base(
            "PrintEgaisSlip")
        {
            if (kpp.IsNullOrEmptyOrWhiteSpace() || !Regex.IsMatch(kpp, RegexHelper.KPPPattern))
            {
                throw new ArgumentException(
                    string.Format(
                        ErrorStrings.ResourceManager.GetString("StringFormatError"),
                        this.GetType().GetProperty(nameof(KPP)).GetDisplayName()),
                    nameof(kpp));
            }

            if (url.IsNullOrEmptyOrWhiteSpace() || !Regex.IsMatch(url, RegexHelper.UrlPattern))
            {
                throw new ArgumentException(
                    string.Format(
                        ErrorStrings.ResourceManager.GetString("StringFormatError"),
                        this.GetType().GetProperty(nameof(Url)).GetDisplayName()),
                    nameof(url));
            }

            if (sign.IsNullOrEmptyOrWhiteSpace())
            {
                throw new ArgumentException(
                    string.Format(
                        ErrorStrings.ResourceManager.GetString("StringFormatError"),
                        this.GetType().GetProperty(nameof(Sign)).GetDisplayName()),
                    nameof(sign));
            }

            ShiftNum = shiftNumber;
            CheckNum = receiptNumber;
            KPP = kpp;
            Url = url;
            Sign = sign;
        }

        /// <summary>
        /// Номер текущей кассовой смены
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Номер текущей кассовой смены")]
        public int ShiftNum { get; }

        /// <summary>
        /// Номер чека
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Номер чека")]
        public int CheckNum { get; }

        /// <summary>
        /// КПП организации, продавшей алкогольную продукцию
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// <item>Должно соответствовать регулярному выражению <see cref="RegexHelper.KPPPattern"/></item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "КПП организации, продавшей алкогольную продукцию")]
        [RegularExpression(RegexHelper.KPPPattern,
            ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "StringFormatError")]
        public string KPP { get; }

        /// <summary>
        /// ИНН организации, продавшей алкогольную продукцию
        /// </summary>
        /// <list type="bullet">
        /// <item>Должно соответствовать регулярному выражению <see cref="RegexHelper.VatinPattern"/></item>
        /// </list>
        [Display(Name = "ИНН организации, продавшей алкогольную продукцию")]
        [RegularExpression(RegexHelper.VatinPattern,
            ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "StringFormatError")]
        public string INN { get; set; }

        /// <summary>
        /// Текст ссылки, полученной от УТМ при подписывании чека
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// <item>Должно соответствовать регулярному выражению <see cref="RegexHelper.UrlPattern"/></item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Текст ссылки, полученной от УТМ при подписывании чека")]
        [RegularExpression(RegexHelper.UrlPattern,
            ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "StringFormatError")]
        public string Url { get; }

        /// <summary>
        /// Отпечаток КЭП, полученный от УТМ при подписывании чека
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Отпечаток КЭП, полученный от УТМ при подписывании чека")]
        public string Sign { get; }
    }
}