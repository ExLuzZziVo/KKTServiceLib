#region

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using KKTServiceLib.Shared.Helpers;
using KKTServiceLib.Shared.Resources;

#endregion

namespace AtolKKTServiceLib.Types.Common
{
    [Description("Оператор (Кассир)")]
    public class OperatorParams
    {
        /// <summary>
        /// Оператор (Кассир)
        /// </summary>
        /// <param name="name">Фамилия и должность оператора (кассира)</param>
        public OperatorParams(string name)
        {
            if (name.IsNullOrEmptyOrWhiteSpace())
            {
                throw new ArgumentException(
                    string.Format(ErrorStrings.ResourceManager.GetString("StringFormatError"),
                        this.GetType().GetProperty(nameof(Name)).GetDisplayName()),
                    nameof(name));
            }

            Name = name;
        }

        /// <summary>
        /// Фамилия и должность оператора (кассира)
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Фамилия и должность оператора (кассира)")]
        public string Name { get; }

        /// <summary>
        /// ИНН оператора (кассира)
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// <item>Должно соответствовать регулярному выражению <see cref="RegexHelper.VatinPattern"/></item>
        /// </list>
        [RegularExpression(RegexHelper.VatinPattern, ErrorMessageResourceType = typeof(ErrorStrings),
            ErrorMessageResourceName = "StringFormatError")]
        [Display(Name = "ИНН оператора (кассира)")]
        public string Vatin { get; set; }
    }
}