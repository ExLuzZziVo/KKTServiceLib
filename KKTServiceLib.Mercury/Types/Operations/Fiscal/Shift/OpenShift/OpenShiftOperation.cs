#region

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using CoreLib.CORE.Helpers.ValidationHelpers.Attributes;
using CoreLib.CORE.Resources;
using KKTServiceLib.Mercury.Types.Common;

#endregion

namespace KKTServiceLib.Mercury.Types.Operations.Fiscal.Shift.OpenShift
{
    [Description("Открытие смены")]
    public class OpenShiftOperation: Operation<OpenShiftResult>
    {
        /// <summary>
        /// Открытие смены
        /// </summary>
        /// <param name="operatorParams">Оператор (кассир)</param>
        public OpenShiftOperation(OperatorParams operatorParams): base("OpenShift")
        {
            CashierInfo = operatorParams ?? throw new ArgumentNullException(nameof(operatorParams));
        }

        /// <summary>
        /// Печать документа на ККТ
        /// </summary>
        /// <remarks>
        /// Значение по умолчанию: true
        /// </remarks>
        [Display(Name = "Печать документа на ККТ")]
        public bool? PrintDoc { get; set; } = true;

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