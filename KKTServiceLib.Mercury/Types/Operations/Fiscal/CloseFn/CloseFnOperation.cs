#region

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using CoreLib.CORE.Helpers.ValidationHelpers.Attributes;
using CoreLib.CORE.Resources;
using KKTServiceLib.Mercury.Types.Common;

#endregion

namespace KKTServiceLib.Mercury.Types.Operations.Fiscal.CloseFn
{
    [Description("Закрытие ФН")]
    public class CloseFnOperation: Operation<CloseFnResult>
    {
        /// <summary>
        /// Закрытие ФН
        /// </summary>
        /// <param name="operatorParams">Оператор (кассир)</param>
        public CloseFnOperation(OperatorParams operatorParams): base("CloseFN")
        {
            CashierInfo = operatorParams ?? throw new ArgumentNullException(nameof(operatorParams));
        }

        /// <summary>
        /// Оператор (кассир)
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Display(Name = "Оператор (кассир)")]
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [ComplexObjectValidation(ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "ComplexObjectValidationError")]
        public OperatorParams CashierInfo { get; }
    }
}