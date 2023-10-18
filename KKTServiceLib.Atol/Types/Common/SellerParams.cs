#region

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using CoreLib.CORE.Helpers.ObjectHelpers;
using CoreLib.CORE.Helpers.StringHelpers;
using CoreLib.CORE.Resources;

#endregion

namespace KKTServiceLib.Atol.Types.Common
{
    [Description("Информация о продавце")]
    public class SellerParams
    {
        /// <summary>
        /// Информация о продавце
        /// </summary>
        /// <param name="email">E-mail отправителя электронной формы чека</param>
        public SellerParams(string email)
        {
            if (email.IsNullOrEmptyOrWhiteSpace() || !Regex.IsMatch(email, RegexExtensions.EmailAddressPattern))
            {
                throw new ArgumentException(
                    string.Format(
                        ValidationStrings.ResourceManager.GetString("StringFormatError"),
                        GetType().GetProperty(nameof(Email)).GetPropertyDisplayName()),
                    nameof(email));
            }

            Email = email;
        }

        /// <summary>
        /// E-mail отправителя электронной формы чека
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// <item>Должно соответствовать регулярному выражению <see cref="RegexExtensions.EmailAddressPattern"/></item>
        /// </list>
        [RegularExpression(
            RegexExtensions.EmailAddressPattern,
            ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "StringFormatError")]
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "E-mail отправителя электронной формы чека")]
        public string Email { get; }
    }
}