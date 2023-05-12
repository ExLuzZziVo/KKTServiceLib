using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using KKTServiceLib.Shared.Helpers;
using KKTServiceLib.Shared.Resources;

namespace KKTServiceLib.Atol.Types.Common
{
    [Description("Пользовательские параметры")]
    public class UserParams
    {
        public UserParams(int id, string value)
        {
            if (value.IsNullOrEmptyOrWhiteSpace())
            {
                throw new ArgumentException(
                    string.Format(ErrorStrings.ResourceManager.GetString("StringFormatError"),
                        GetType().GetProperty(nameof(Value)).GetDisplayName()), nameof(value));
            }

            Id = id;
            Value = value;
        }

        /// <summary>
        /// Номер параметра
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Display(Name = "Номер параметра")]
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        public int Id { get; }

        /// <summary>
        /// Значение параметра
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Display(Name = "Значение параметра")]
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        public string Value { get; }
    }
}