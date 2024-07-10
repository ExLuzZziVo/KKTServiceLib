#region

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using CoreLib.CORE.Helpers.ObjectHelpers;
using CoreLib.CORE.Helpers.ValidationHelpers.Attributes;
using CoreLib.CORE.Resources;
using KKTServiceLib.Mercury.Types.Common;
using KKTServiceLib.Mercury.Types.Converters;
using KKTServiceLib.Mercury.Types.Enums;

#endregion

namespace KKTServiceLib.Mercury.Types.Operations.Fiscal.Cash.CreateCashManipulation
{
    [Description("Создание операции по внесению или выплате наличных")]
    public class CreateCashManipulationOperation: Operation<CreateCashManipulationResult>
    {
        /// <summary>
        /// Создание операции по внесению или выплате наличных
        /// </summary>
        /// <param name="type">Внесение или выплата наличных</param>
        /// <param name="operatorParams">Оператор (кассир)</param>
        /// <param name="cashSum">Сумма наличных</param>
        public CreateCashManipulationOperation(CashManipulationType type, OperatorParams operatorParams,
            decimal cashSum): base(type.ToString())
        {
            if (cashSum < (decimal)0.01 || cashSum > 21474836)
            {
                throw new ArgumentException(
                    string.Format(ValidationStrings.ResourceManager.GetString("DigitRangeValuesError"),
                        GetType().GetProperty(nameof(Cash)).GetPropertyDisplayName(), 0.01, 21474836),
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
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Cумма наличных")]
        [JsonConverter(typeof(MoneyConverter))]
        [Range(0.01, 21474836, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "DigitRangeValuesError")]
        public decimal Cash { get; }

        /// <summary>
        /// Оператор (кассир)
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Оператор (кассир)")]
        [ComplexObjectValidation(ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "ComplexObjectValidationError")]
        public OperatorParams CashierInfo { get; }
    }
}