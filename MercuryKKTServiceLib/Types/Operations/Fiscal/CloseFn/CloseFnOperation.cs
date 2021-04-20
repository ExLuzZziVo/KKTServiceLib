using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using KKTServiceLib.Shared.Resources;
using KKTServiceLib.Shared.Types.ValidationAttributes;
using MercuryKKTServiceLib.Types.Common;

namespace MercuryKKTServiceLib.Types.Operations.Fiscal.CloseFn
{
    [Description("Закрытие ФН")]
    public class CloseFnOperation : Operation<CloseFnResult>
    {
        /// <summary>
        /// Закрытие ФН
        /// </summary>
        /// <param name="operatorParams">Оператор (кассир)</param>
        public CloseFnOperation(OperatorParams operatorParams) : base("CloseFN")
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
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        [ComplexObjectValidation(ErrorMessageResourceType = typeof(ErrorStrings),
            ErrorMessageResourceName = "ComplexObjectValidationError")]
        public OperatorParams CashierInfo { get; }
    }
}