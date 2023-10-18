#region

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using CoreLib.CORE.Helpers.ObjectHelpers;
using CoreLib.CORE.Helpers.StringHelpers;
using CoreLib.CORE.Resources;
using KKTServiceLib.Atol.Types.Enums;

#endregion

namespace KKTServiceLib.Atol.Types.Common.Document
{
    [Description("Дополнительный реквизит чека (БСО)")]
    public class AdditionalAttributeDocumentParams : DocumentParams
    {
        /// <summary>
        /// Дополнительный реквизит чека (БСО)
        /// </summary>
        /// <param name="value">Значение</param>
        public AdditionalAttributeDocumentParams(string value) : base(PrintDocumentType.AdditionalAttribute)
        {
            if (value.IsNullOrEmptyOrWhiteSpace() || value.Length > 16)
            {
                throw new ArgumentException(
                    string.Format(ValidationStrings.ResourceManager.GetString("StringFormatError"),
                        GetType().GetProperty(nameof(Value)).GetPropertyDisplayName()), nameof(value));
            }

            Value = value;
        }

        /// <summary>
        /// Значение дополнительного реквизита чека (БСО)
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// <item>Максимальная длина: 16</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [MaxLength(16, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringMaxLengthError")]
        [Display(Name = "Значение дополнительного реквизита чека (БСО)")]
        public string Value { get; }

        /// <summary>
        /// Печать реквизита на чековой ленте
        /// </summary>
        /// <remarks>
        /// Значение по умолчанию: true
        /// </remarks>
        [Display(Name = "Печать реквизита на чековой ленте")]
        public bool Print { get; set; } = true;
    }
}