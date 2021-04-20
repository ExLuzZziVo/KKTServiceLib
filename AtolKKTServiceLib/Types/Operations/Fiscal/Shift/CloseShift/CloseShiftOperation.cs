#region

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Atol.Drivers10.Fptr;
using AtolKKTServiceLib.Types.Common;
using AtolKKTServiceLib.Types.Interfaces;
using KKTServiceLib.Shared.Resources;
using KKTServiceLib.Shared.Types.Exceptions;
using KKTServiceLib.Shared.Types.ValidationAttributes;

#endregion

namespace AtolKKTServiceLib.Types.Operations.Fiscal.Shift.CloseShift
{
    [Description("Закрытие смены")]
    public class CloseShiftOperation : Operation<CloseShiftResult>
    {
        /// <summary>
        /// Закрытие смены
        /// </summary>
        /// <param name="operatorParams">Оператор (кассир)</param>
        public CloseShiftOperation(OperatorParams operatorParams) : base("closeShift")
        {
            Operator = operatorParams ?? throw new ArgumentNullException(nameof(operatorParams));
        }

        /// <summary>
        /// Оператор (кассир)
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [ComplexObjectValidation(ErrorMessageResourceType = typeof(ErrorStrings),
            ErrorMessageResourceName = "ComplexObjectValidationError")]
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Оператор (кассир)")]
        public OperatorParams Operator { get; }

        /// <summary>
        /// Элементы для печати до документа
        /// </summary>
        [ComplexObjectCollectionValidation(AllowNullItems = false, ErrorMessageResourceType = typeof(ErrorStrings),
            ErrorMessageResourceName = "ComplexObjectCollectionValidationError")]
        [Display(Name = "Элементы для печати до документа")]
        public ICommonDocumentElement[] PreItems { get; set; }

        /// <summary>
        /// Элементы для печати после документа
        /// </summary>
        [ComplexObjectCollectionValidation(AllowNullItems = false, ErrorMessageResourceType = typeof(ErrorStrings),
            ErrorMessageResourceName = "ComplexObjectCollectionValidationError")]
        [Display(Name = "Элементы для печати после документа")]
        public ICommonDocumentElement[] PostItems { get; set; }

        /// <summary>
        /// Электронный отчет
        /// </summary>
        [Display(Name = "Электронный отчет")]
        public bool Electronically { get; set; }
    }
}