#region

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using KKTServiceLib.Atol.Types.Enums;
using KKTServiceLib.Shared.Helpers;
using KKTServiceLib.Shared.Resources;

#endregion

namespace KKTServiceLib.Atol.Types.Common.Document
{
    [Description("Дополнительный реквизит пользователя")]
    public class UserAttributeDocumentParams : DocumentParams
    {
        /// <summary>
        /// Дополнительный реквизит пользователя
        /// </summary>
        /// <param name="name">Наименование</param>
        /// <param name="value">Значение</param>
        public UserAttributeDocumentParams(string name, string value) : base(PrintDocumentType.UserAttribute)
        {
            if (name.IsNullOrEmptyOrWhiteSpace())
            {
                throw new ArgumentException(
                    string.Format(ErrorStrings.ResourceManager.GetString("StringFormatError"),
                        GetType().GetProperty(nameof(Name)).GetDisplayName()),
                    nameof(name));
            }

            if (value.IsNullOrEmptyOrWhiteSpace())
            {
                throw new ArgumentException(
                    string.Format(ErrorStrings.ResourceManager.GetString("StringFormatError"),
                        GetType().GetProperty(nameof(Value)).GetDisplayName()),
                    nameof(value));
            }

            Name = name;
            Value = value;
        }

        /// <summary>
        /// Наименование дополнительного реквизита пользователя
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Наименование дополнительного реквизита пользователя")]
        public string Name { get; }

        /// <summary>
        /// Значение дополнительного реквизита пользователя
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Значение дополнительного реквизита пользователя")]
        public string Value { get; }

        /// <summary>
        /// Печатать или не печатать реквизит на чековой ленте
        /// </summary>
        /// <remarks>
        /// Значение по умолчанию: true
        /// </remarks>
        [Display(Name = "Печатать или не печатать реквизит на чековой ленте")]
        public bool Print { get; set; } = true;
    }
}