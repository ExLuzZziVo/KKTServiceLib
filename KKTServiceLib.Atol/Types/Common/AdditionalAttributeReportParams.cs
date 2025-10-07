#region

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using CoreLib.CORE.Helpers.ObjectHelpers;
using CoreLib.CORE.Helpers.StringHelpers;
using CoreLib.CORE.Resources;

#endregion

namespace KKTServiceLib.Atol.Types.Common
{
    [Description("Дополнительный реквизит отчёта")]
    public class AdditionalAttributeReportParams: IValidatableObject
    {
        /// <summary>
        /// Дополнительный реквизит отчёта
        /// </summary>
        /// <param name="name">Наименование</param>
        /// <param name="value">Значение</param>
        public AdditionalAttributeReportParams(string name, string value)
        {
            if (name.IsNullOrEmptyOrWhiteSpace())
            {
                throw new ArgumentException(
                    string.Format(ValidationStrings.ResourceManager.GetString("StringFormatError"),
                        GetType().GetProperty(nameof(Name)).GetPropertyDisplayName()),
                    nameof(name));
            }

            if (value.IsNullOrEmptyOrWhiteSpace())
            {
                throw new ArgumentException(
                    string.Format(ValidationStrings.ResourceManager.GetString("StringFormatError"),
                        GetType().GetProperty(nameof(Value)).GetPropertyDisplayName()),
                    nameof(value));
            }

            if (name.Length > 32)
            {
                throw new ArgumentException(
                    string.Format(ValidationStrings.ResourceManager.GetString("StringMaxLengthError"),
                        GetType().GetProperty(nameof(Name)).GetPropertyDisplayName(), 32), nameof(name));
            }

            if (Encoding.UTF8.GetByteCount(value) > 32)
            {
                throw new ArgumentException(
                    string.Format(ValidationStrings.ResourceManager.GetString("StringMaxSizeError"),
                        GetType().GetProperty(nameof(Value)).GetPropertyDisplayName(), 32), nameof(value));
            }

            Name = name;
            Value = value;
        }

        /// <summary>
        /// Название реквизита
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// <item>Максимальная длина: 32</item>
        /// </list>
        [Display(Name = "Название реквизита")]
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [MaxLength(32, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringMaxLengthError")]
        public string Name { get; }

        /// <summary>
        /// Значение реквизита
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// <item>Максимальная длина: 32 БАЙТА</item>
        /// </list>
        [Display(Name = "Значение реквизита")]
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        public string Value { get; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Encoding.UTF8.GetByteCount(Value) > 32)
            {
                yield return new ValidationResult(
                    string.Format(ValidationStrings.ResourceManager.GetString("StringMaxSizeError"),
                        GetType().GetProperty(nameof(Value)).GetPropertyDisplayName(), 32),
                    new[] { nameof(Value) });
            }
        }
    }
}
