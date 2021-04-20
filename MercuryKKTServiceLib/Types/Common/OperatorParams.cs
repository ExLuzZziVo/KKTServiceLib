using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using KKTServiceLib.Shared.Helpers;
using KKTServiceLib.Shared.Resources;

namespace MercuryKKTServiceLib.Types.Common
{
    [Description("Оператор (Кассир)")]
    public class OperatorParams
    {
        /// <summary>
        /// Оператор (Кассир)
        /// </summary>
        /// <param name="name">Фамилия и должность</param>
        public OperatorParams(string name)
        {
            if (name.IsNullOrEmptyOrWhiteSpace())
            {
                throw new ArgumentException(
                    string.Format(
                        ErrorStrings.ResourceManager.GetString("StringFormatError"),
                        this.GetType().GetProperty(nameof(CashierName)).GetDisplayName()),
                    nameof(name));
            }

            CashierName = name;
        }

        /// <summary>
        /// Фамилия и должность оператора (кассира)
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Фамилия и должность оператора (кассира)")]
        public string CashierName { get; }

        /// <summary>
        /// ИНН кассира
        /// </summary>
        /// <list type="bullet">
        /// <item>Должно соответствовать регулярному выражению <see cref="RegexHelper.VatinPattern"/></item>
        /// </list>
        [Display(Name = "ИНН кассира")]
        [RegularExpression(RegexHelper.VatinPattern, ErrorMessageResourceType = typeof(ErrorStrings),
            ErrorMessageResourceName = "StringFormatError")]
        public string CashierINN { get; set; }
    }
}