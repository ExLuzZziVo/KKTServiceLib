using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using KKTServiceLib.Shared.Helpers;
using KKTServiceLib.Shared.Resources;

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
                        ErrorStrings.ResourceManager.GetString("StringFormatError"),
                        this.GetType().GetProperty(nameof(AttrName)).GetDisplayName()),
                    nameof(name));
            }

            if (value.IsNullOrEmptyOrWhiteSpace() || name.Length > 256)
            {
                throw new ArgumentException(
                    string.Format(
                        ErrorStrings.ResourceManager.GetString("StringFormatError"),
                        this.GetType().GetProperty(nameof(AttrValue)).GetDisplayName()),
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
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        [MaxLength(64, ErrorMessageResourceType = typeof(ErrorStrings),
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
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        [MaxLength(256, ErrorMessageResourceType = typeof(ErrorStrings),
            ErrorMessageResourceName = "StringMaxLengthError")]
        [Display(Name = "Значение дополнительного реквизита")]
        public string AttrValue { get; }
    }
}