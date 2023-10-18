#region

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using CoreLib.CORE.Helpers.ValidationHelpers.Attributes;
using CoreLib.CORE.Resources;
using KKTServiceLib.Mercury.Types.Common;

#endregion

namespace KKTServiceLib.Mercury.Types.Operations.Fiscal.CreateExchangeStatusReport
{
    [Description("Создание отчета о текущем состоянии расчетов")]
    public class CreateExchangeStatusReportOperation : Operation<CreateExchangeStatusReportResult>
    {
        /// <summary>
        /// Создание отчета о текущем состоянии расчетов
        /// </summary>
        /// <param name="operatorParams">Оператор (кассир)</param>
        public CreateExchangeStatusReportOperation(OperatorParams operatorParams) : base("ReportStatusOfSettlements")
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