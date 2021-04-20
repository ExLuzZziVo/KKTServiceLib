#region

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Atol.Drivers10.Fptr;
using AtolKKTServiceLib.Types.Common;
using KKTServiceLib.Shared.Resources;
using KKTServiceLib.Shared.Types.Exceptions;
using KKTServiceLib.Shared.Types.ValidationAttributes;

#endregion

namespace AtolKKTServiceLib.Types.Operations.Fiscal.Fn.CloseFn
{
    [Description("Закрытие ФН")]
    public class CloseFnOperation : Operation<CloseFnResult>
    {
        /// <summary>
        /// Закрытие ФН
        /// </summary>
        /// <param name="operatorParams">Оператор (кассир)</param>
        public CloseFnOperation(OperatorParams operatorParams) : base("closeArchive")
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
        /// Электронный отчет
        /// </summary>
        [Display(Name = "Электронный отчет")]
        public bool Electronically { get; set; }
    }
}