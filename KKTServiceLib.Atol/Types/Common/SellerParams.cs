#region

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using KKTServiceLib.Shared.Helpers;
using KKTServiceLib.Shared.Resources;

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
            if (email.IsNullOrEmptyOrWhiteSpace() || !Regex.IsMatch(email, RegexHelper.EmailAddressPattern))
            {
                throw new ArgumentException(
                    string.Format(
                        ErrorStrings.ResourceManager.GetString("StringFormatError"),
                        this.GetType().GetProperty(nameof(Email)).GetDisplayName()),
                    nameof(email));
            }

            Email = email;
        }

        /// <summary>
        /// E-mail отправителя электронной формы чека
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// <item>Должно соответствовать регулярному выражению <see cref="RegexHelper.EmailAddressPattern"/></item>
        /// </list>
        [RegularExpression(
            RegexHelper.EmailAddressPattern,
            ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "StringFormatError")]
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "E-mail отправителя электронной формы чека")]
        public string Email { get; }
    }
}