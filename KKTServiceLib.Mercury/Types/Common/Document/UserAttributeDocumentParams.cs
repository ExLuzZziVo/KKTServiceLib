#region

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using CoreLib.CORE.Helpers.ObjectHelpers;
using CoreLib.CORE.Helpers.StringHelpers;
using CoreLib.CORE.Resources;

#endregion

namespace KKTServiceLib.Mercury.Types.Common.Document
{
    [Description("Дополнительный реквизит пользователя")]
    public class UserAttributeDocumentParams
    {
        /// <summary>
        /// Дополнительный реквизит пользователя
        /// </summary>
        /// <param name="name">Наименование</param>
        /// <param name="value">Значение</param>
        public UserAttributeDocumentParams(string name, string value)
        {
            if (name.IsNullOrEmptyOrWhiteSpace() || name.Length > 64)
            {
                throw new ArgumentException(
                    string.Format(
                        ValidationStrings.ResourceManager.GetString("StringFormatError"),
                        GetType().GetProperty(nameof(AttrName)).GetPropertyDisplayName()),
                    nameof(name));
            }

            if (value.IsNullOrEmptyOrWhiteSpace() || name.Length > 256)
            {
                throw new ArgumentException(
                    string.Format(
                        ValidationStrings.ResourceManager.GetString("StringFormatError"),
                        GetType().GetProperty(nameof(AttrValue)).GetPropertyDisplayName()),
                    nameof(value));
            }

            AttrName = name;
            AttrValue = value;
        }

        /// <summary>
        /// Наименование дополнительного реквизита
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// <item>Максимальная длина: 64</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [MaxLength(64, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringMaxLengthError")]
        [Display(Name = "Наименование дополнительного реквизита")]
        public string AttrName { get; }

        /// <summary>
        /// Значение дополнительного реквизита
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// <item>Максимальная длина: 256</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [MaxLength(256, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringMaxLengthError")]
        [Display(Name = "Значение дополнительного реквизита")]
        public string AttrValue { get; }
    }
}