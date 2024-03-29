﻿#region

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using CoreLib.CORE.Helpers.ObjectHelpers;
using CoreLib.CORE.Helpers.StringHelpers;
using CoreLib.CORE.Resources;
using KKTServiceLib.Mercury.Types.Enums;
using KKTServiceLib.Shared.Helpers;
using KKTServiceLib.Shared.Types.ValidationAttributes;

#endregion

namespace KKTServiceLib.Mercury.Types.Common.Agent
{
    [Description("Данные агента")]
    public class AgentParams
    {
        /// <summary>
        /// Данные агента
        /// </summary>
        /// <param name="agentType">Тип агента</param>
        /// <param name="supplierVatin">ИНН поставщика</param>
        public AgentParams(AgentType agentType, string supplierVatin)
        {
            if (supplierVatin.IsNullOrEmptyOrWhiteSpace() ||
                !Regex.IsMatch(supplierVatin, RegexExtensions_Ru.VatinPattern))
            {
                throw new ArgumentException(
                    string.Format(
                        ValidationStrings.ResourceManager.GetString("StringFormatError"),
                        GetType().GetProperty(nameof(SupplierINN)).GetPropertyDisplayName()),
                    nameof(supplierVatin));
            }

            Code = agentType;
            SupplierINN = supplierVatin;
        }

        /// <summary>
        /// Вид агента
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Вид агента")]
        public AgentType Code { get; }

        /// <summary>
        /// Наименование операции банковского платежного агента
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле, если тип агента - <see cref="AgentType.BankPayingAgent"/> или <see cref="AgentType.BankPayingSubagent"/>. В остальных случаях должно отсутствовать</item>
        /// </list>
        [Display(Name = "Наименование операции банковского платежного агента")]
        public string PayingOp { get; set; }

        /// <summary>
        /// Телефоны платежного агента
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле, если тип агента - <see cref="AgentType.BankPayingAgent"/>, <see cref="AgentType.BankPayingSubagent"/>, <see cref="AgentType.PayingAgent"/> или <see cref="AgentType.PayingSubagent"/>. В остальных случаях должно отсутствовать</item>
        /// <item>Минимальное кол-во элементов: 1</item>
        /// <item>Все элементы должны соответствовать регулярному выражению <see cref="RegexHelper.PhoneNumberPattern"/></item>
        /// </list>
        [Display(Name = "Телефоны платежного агента")]
        [RegularExpressionCollectionValidation(RegexHelper.PhoneNumberPattern)]
        [MinLength(1, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "CollectionMinLengthError")]
        public ISet<string> PayingPhone { get; set; }

        /// <summary>
        /// Наименование оператора перевода
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле, если тип агента - <see cref="AgentType.BankPayingAgent"/> или <see cref="AgentType.BankPayingSubagent"/>. В остальных случаях должно отсутствовать</item>
        /// </list>
        [Display(Name = "Наименование оператора перевода")]
        public string TransfName { get; set; }

        /// <summary>
        /// ИНН оператора перевода
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// <item>Должно соответствовать регулярному выражению <see cref="RegexExtensions_Ru.VatinPattern"/></item>
        /// </list>
        [Display(Name = "ИНН оператора перевода")]
        [RegularExpression(RegexExtensions_Ru.VatinPattern, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringFormatError")]
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        public string TransfINN { get; set; }

        /// <summary>
        /// Адрес оператора перевода
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле, если тип агента - <see cref="AgentType.BankPayingAgent"/> или <see cref="AgentType.BankPayingSubagent"/>. В остальных случаях должно отсутствовать</item>
        /// </list>
        [Display(Name = "Адрес оператора перевода")]
        public string TransfAddress { get; set; }

        /// <summary>
        /// Телефоны оператора перевода
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле, если тип агента - <see cref="AgentType.BankPayingAgent"/> или <see cref="AgentType.BankPayingSubagent"/>. В остальных случаях должно отсутствовать</item>
        /// <item>Минимальное кол-во элементов: 1</item>
        /// <item>Все элементы должны соответствовать регулярному выражению <see cref="RegexHelper.PhoneNumberPattern"/></item>
        /// </list>
        [Display(Name = "Телефоны оператора перевода")]
        [RegularExpressionCollectionValidation(RegexHelper.PhoneNumberPattern)]
        [MinLength(1, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "CollectionMinLengthError")]
        public ISet<string> TransfPhone { get; set; }

        /// <summary>
        /// Телефоны оператора по приему платежей
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле, если тип агента - <see cref="AgentType.PayingAgent"/> или <see cref="AgentType.PayingSubagent"/>. В остальных случаях должно отсутствовать</item>
        /// <item>Минимальное кол-во элементов: 1</item>
        /// <item>Все элементы должны соответствовать регулярному выражению <see cref="RegexHelper.PhoneNumberPattern"/></item>
        /// </list>
        [Display(Name = "Телефоны оператора по приему платежей")]
        [RegularExpressionCollectionValidation(RegexHelper.PhoneNumberPattern)]
        [MinLength(1, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "CollectionMinLengthError")]
        public ISet<string> OperatorPhone { get; set; }

        /// <summary>
        /// Телефоны поставщика
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле, если тип агента - <see cref="AgentType.BankPayingAgent"/>, <see cref="AgentType.BankPayingSubagent"/>, <see cref="AgentType.PayingAgent"/> или <see cref="AgentType.PayingSubagent"/>. В остальных случаях должно отсутствовать</item>
        /// <item>Минимальное кол-во элементов: 1</item>
        /// <item>Все элементы должны соответствовать регулярному выражению <see cref="RegexHelper.PhoneNumberPattern"/></item>
        /// </list>
        [Display(Name = "Телефоны поставщика")]
        [RegularExpressionCollectionValidation(RegexHelper.PhoneNumberPattern)]
        [MinLength(1, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "CollectionMinLengthError")]
        public ISet<string> SupplierPhone { get; set; }

        /// <summary>
        /// ИНН поставщика
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// <item>Должно соответствовать регулярному выражению <see cref="RegexExtensions_Ru.VatinPattern"/></item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "ИНН поставщика")]
        [RegularExpression(RegexExtensions_Ru.VatinPattern, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringFormatError")]
        public string SupplierINN { get; }

        /// <summary>
        /// Наименование поставщика
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле, если тип агента - <see cref="AgentType.BankPayingAgent"/>, <see cref="AgentType.BankPayingSubagent"/>, <see cref="AgentType.PayingAgent"/> или <see cref="AgentType.PayingSubagent"/>. В остальных случаях должно отсутствовать</item>
        /// </list>
        [Display(Name = "Наименование поставщика")]
        public string SupplierName { get; set; }
    }
}