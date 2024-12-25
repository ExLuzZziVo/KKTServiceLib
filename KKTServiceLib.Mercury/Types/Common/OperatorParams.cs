#region

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using CoreLib.CORE.Helpers.ObjectHelpers;
using CoreLib.CORE.Helpers.StringHelpers;
using CoreLib.CORE.Resources;

#endregion

namespace KKTServiceLib.Mercury.Types.Common
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
                        ValidationStrings.ResourceManager.GetString("StringFormatError"),
                        GetType().GetProperty(nameof(CashierName)).GetPropertyDisplayName()),
                    nameof(name));
            }

            CashierName = name;
        }

        [JsonConstructor]
        private OperatorParams() { }

        /// <summary>
        /// Фамилия и должность оператора (кассира)
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Фамилия и должность оператора (кассира)")]
        public string CashierName { get; }

        /// <summary>
        /// ИНН кассира
        /// </summary>
        /// <list type="bullet">
        /// <item>Должно соответствовать регулярному выражению <see cref="RegexExtensions_Ru.VatinPattern"/></item>
        /// </list>
        [Display(Name = "ИНН кассира")]
        [RegularExpression(RegexExtensions_Ru.VatinPattern, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringFormatError")]
        public string CashierINN { get; set; }
    }
}
