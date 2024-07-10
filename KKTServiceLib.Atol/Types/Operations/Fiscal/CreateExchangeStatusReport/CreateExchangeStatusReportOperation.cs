#region

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using CoreLib.CORE.Helpers.ValidationHelpers.Attributes;
using CoreLib.CORE.Resources;
using KKTServiceLib.Atol.Types.Common;
using KKTServiceLib.Atol.Types.Interfaces;

#endregion

namespace KKTServiceLib.Atol.Types.Operations.Fiscal.CreateExchangeStatusReport
{
    [Description("Создание отчета о текущем состоянии расчетов")]
    public class CreateExchangeStatusReportOperation: Operation<CreateExchangeStatusReportResult>
    {
        /// <summary>
        /// Отчет о текущем состоянии расчетов
        /// </summary>
        /// <param name="operatorParams">Оператор (кассир)</param>
        public CreateExchangeStatusReportOperation(OperatorParams operatorParams): base("reportOfdExchangeStatus")
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
        /// Элементы для печати до документа
        /// </summary>
        [ComplexObjectCollectionValidation(AllowNullItems = false, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "ComplexObjectCollectionValidationError")]
        [Display(Name = "Элементы для печати до документа")]
        public ICommonDocumentElement[] PreItems { get; set; }

        /// <summary>
        /// Элементы для печати после документа
        /// </summary>
        [ComplexObjectCollectionValidation(AllowNullItems = false, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "ComplexObjectCollectionValidationError")]
        [Display(Name = "Элементы для печати после документа")]
        public ICommonDocumentElement[] PostItems { get; set; }
    }
}