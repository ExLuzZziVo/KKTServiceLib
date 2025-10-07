#region

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using CoreLib.CORE.Helpers.ValidationHelpers.Attributes;
using CoreLib.CORE.Resources;
using KKTServiceLib.Atol.Types.Common;

#endregion

namespace KKTServiceLib.Atol.Types.Operations.Fiscal.Fn.CloseFn
{
    [Description("Закрытие ФН")]
    public class CloseFnOperation: Operation<CloseFnResult>
    {
        /// <summary>
        /// Закрытие ФН
        /// </summary>
        /// <param name="operatorParams">Оператор (кассир)</param>
        public CloseFnOperation(OperatorParams operatorParams): base("closeArchive")
        {
            Operator = operatorParams ?? throw new ArgumentNullException(nameof(operatorParams));
        }

        /// <summary>
        /// Оператор (кассир)
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [ComplexObjectValidation(ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "ComplexObjectValidationError")]
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Оператор (кассир)")]
        public OperatorParams Operator { get; }

        /// <summary>
        /// Электронный отчет
        /// </summary>
        [Display(Name = "Электронный отчет")]
        public bool Electronically { get; set; }

        /// <summary>
        /// Дополнительный реквизит отчета
        /// </summary>
        [ComplexObjectValidation(ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "ComplexObjectValidationError")]
        [Display(Name = "Дополнительный реквизит отчета")]
        public AdditionalAttributeReportParams AdditionalAttribute { get; set; }

        /// <summary>
        /// Адрес расчетов
        /// </summary>
        [Display(Name = "Адрес расчетов")]
        public string Address { get; set; }

        /// <summary>
        /// Место расчетов
        /// </summary>
        [Display(Name = "Место расчетов")]
        public string PaymentAddress { get; set; }
    }
}
