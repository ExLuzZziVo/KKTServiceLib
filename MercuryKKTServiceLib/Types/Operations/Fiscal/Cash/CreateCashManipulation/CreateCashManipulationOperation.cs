﻿using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using KKTServiceLib.Shared.Helpers;
using KKTServiceLib.Shared.Resources;
using KKTServiceLib.Shared.Types.ValidationAttributes;
using MercuryKKTServiceLib.Types.Common;
using MercuryKKTServiceLib.Types.Converters;
using MercuryKKTServiceLib.Types.Enums;
using Newtonsoft.Json;

namespace MercuryKKTServiceLib.Types.Operations.Fiscal.Cash.CreateCashManipulation
{
    [Description("Создание операции по внесению или выплате наличных")]
    public class CreateCashManipulationOperation : Operation<CreateCashManipulationResult>
    {
        /// <summary>
        /// Создание операции по внесению или выплате наличных
        /// </summary>
        /// <param name="type">Внесение или выплата наличных</param>
        /// <param name="operatorParams">Оператор (кассир)</param>
        /// <param name="cashSum">Сумма наличных</param>
        public CreateCashManipulationOperation(CashManipulationType type, OperatorParams operatorParams,
            decimal cashSum) : base(type.ToString())
        {
            if (cashSum < (decimal) 0.01 || cashSum > 21474836)
            {
                throw new ArgumentException(
                    string.Format(ErrorStrings.ResourceManager.GetString("DigitRangeValuesError"),
                        this.GetType().GetProperty(nameof(Cash)).GetDisplayName(), 0.01, 21474836),
                    nameof(cashSum));
            }

            CashierInfo = operatorParams ?? throw new ArgumentNullException(nameof(operatorParams));
            Cash = cashSum;
        }

        /// <summary>
        /// Cумма наличных
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// <item>Должно лежать в диапазоне: 0.01-21474836</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Cумма наличных")]
        [JsonConverter(typeof(MoneyConverter))]
        [Range(0.01, 21474836, ErrorMessageResourceType = typeof(ErrorStrings),
            ErrorMessageResourceName = "DigitRangeValuesError")]
        public decimal Cash { get; }

        /// <summary>
        /// Оператор (кассир)
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Оператор (кассир)")]
        [ComplexObjectValidation(ErrorMessageResourceType = typeof(ErrorStrings),
            ErrorMessageResourceName = "ComplexObjectValidationError")]
        public OperatorParams CashierInfo { get; }
    }
}