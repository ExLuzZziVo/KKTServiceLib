using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using KKTServiceLib.Atol.Types.Common.MarkingCodes;
using KKTServiceLib.Shared.Resources;
using KKTServiceLib.Shared.Types.ValidationAttributes;

namespace KKTServiceLib.Atol.Types.Operations.Fiscal.Ism.BeginMarkingCodeValidation
{
    [Description("Начало проверки КМ")]
    public class BeginMarkingCodeValidationOperation : Operation<BeginMarkingCodeValidationResult>
    {
        /// <summary>
        /// Начало проверки КМ
        /// </summary>
        /// <param name="markingCodeParams">КМ для проверки</param>
        public BeginMarkingCodeValidationOperation(MarkingCodeParams_12 markingCodeParams) : base(
            "beginMarkingCodeValidation ")
        {
            if (markingCodeParams == null)
            {
                throw new ArgumentNullException(nameof(markingCodeParams));
            }

            if (markingCodeParams.IsPositionMarkingCodeParams)
            {
                throw new ArgumentException(Resources.ErrorStrings.ResourceManager.GetString("MarkingCodeCheckTypeError"));
            }

            Params = markingCodeParams;
        }

        /// <summary>
        /// КМ для проверки
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Display(Name = "КМ для проверки")]
        [ComplexObjectValidation(ErrorMessageResourceType = typeof(ErrorStrings),
            ErrorMessageResourceName = "ComplexObjectValidationError")]
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        public MarkingCodeParams_12 Params { get; }
    }
}