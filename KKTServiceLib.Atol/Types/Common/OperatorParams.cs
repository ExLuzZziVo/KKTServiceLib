#region

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using CoreLib.CORE.Helpers.ObjectHelpers;
using CoreLib.CORE.Helpers.StringHelpers;
using CoreLib.CORE.Resources;

#endregion

namespace KKTServiceLib.Atol.Types.Common
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
                    string.Format(ValidationStrings.ResourceManager.GetString("StringFormatError"),
                        GetType().GetProperty(nameof(Name)).GetPropertyDisplayName()),
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
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Фамилия и должность оператора (кассира)")]
        public string Name { get; }

        /// <summary>
        /// ИНН оператора (кассира)
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// <item>Должно соответствовать регулярному выражению <see cref="RegexExtensions_Ru.VatinPattern"/></item>
        /// </list>
        [RegularExpression(RegexExtensions_Ru.VatinPattern, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringFormatError")]
        [Display(Name = "ИНН оператора (кассира)")]
        public string Vatin { get; set; }
    }
}