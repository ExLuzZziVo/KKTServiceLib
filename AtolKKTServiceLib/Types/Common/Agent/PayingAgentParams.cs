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
    [Description("Данные платежного агента")]
    public class PayingAgentParams
    {
        /// <summary>
        /// Данные платежного агента
        /// </summary>
        /// <param name="operation">Наименование операции</param>
        /// <param name="phones">Телефоны</param>
        public PayingAgentParams(string operation, ISet<string> phones)
        {
            if (operation.IsNullOrEmptyOrWhiteSpace())
            {
                throw new ArgumentException(
                    string.Format(ErrorStrings.ResourceManager.GetString("StringFormatError"),
                        this.GetType().GetProperty(nameof(Operation)).GetDisplayName()),
                    nameof(operation));
            }

            if (phones?.Any() != true)
            {
                throw new ArgumentException(string.Format(ErrorStrings.ResourceManager.GetString("MinLengthError"),
                        this.GetType().GetProperty(nameof(Phones)).GetDisplayName(), 1),
                    nameof(phones));
            }

            Operation = operation;
            Phones = phones;
        }

        /// <summary>
        /// Операция платежного агента
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Операция платежного агента")]
        public string Operation { get; }

        /// <summary>
        /// Телефоны платежного агента
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// <item>Минимальное кол-во элементов: 1</item>
        /// <item>Все элементы должны соответствовать регулярному выражению <see cref="RegexHelper.PhoneNumberPattern"/></item>
        /// </list>
        [RegularExpressionCollectionValidation(RegexHelper.PhoneNumberPattern)]
        [MinLength(1, ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "MinLengthError")]
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Телефоны платежного агента")]
        public ISet<string> Phones { get; }
    }
}