#region

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using KKTServiceLib.Shared.Helpers;
using KKTServiceLib.Shared.Resources;
using KKTServiceLib.Shared.Types.ValidationAttributes;

#endregion

namespace AtolKKTServiceLib.Types.Common.Agent
{
    [Description("Данные оператора по приему платежей")]
    public class ReceivePaymentsOperatorParams
    {
        /// <summary>
        /// Данные оператора по приему платежей
        /// </summary>
        /// <param name="phones">Телефоны</param>
        public ReceivePaymentsOperatorParams(ISet<string> phones)
        {
            if (phones?.Any() != true)
            {
                throw new ArgumentException(string.Format(ErrorStrings.ResourceManager.GetString("MinLengthError"),
                        this.GetType().GetProperty(nameof(Phones)).GetDisplayName(), 1),
                    nameof(phones));
            }

            Phones = phones;
        }

        /// <summary>
        /// Телефоны оператора по приему платежей
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// <item>Минимальное кол-во элементов: 1</item>
        /// <item>Все элементы должны соответствовать регулярному выражению <see cref="RegexHelper.PhoneNumberPattern"/></item>
        /// </list>
        [RegularExpressionCollectionValidation(RegexHelper.PhoneNumberPattern)]
        [MinLength(1, ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "MinLengthError")]
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Телефоны оператора по приему платежей")]
        public ISet<string> Phones { get; }
    }
}