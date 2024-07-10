#region

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using CoreLib.CORE.Helpers.ObjectHelpers;
using CoreLib.CORE.Helpers.ValidationHelpers.Attributes;
using CoreLib.CORE.Resources;
using KKTServiceLib.Atol.Resources;
using KKTServiceLib.Atol.Types.Common.MarkingCodes;

#endregion

namespace KKTServiceLib.Atol.Types.Operations.Fiscal.Ism.ForceAddMarkingCodesToBuffer
{
    [Description("Принудительное добавление массива КМ в таблицу проверенных КМ")]
    public class ForceAddMarkingCodesToBufferOperation: Operation<ForceAddMarkingCodesToBufferResult[]>
    {
        /// <summary>
        /// Принудительное добавление массива КМ в таблицу проверенных КМ
        /// </summary>
        /// <param name="markingCodeParams">Массив КМ для проверки</param>
        public ForceAddMarkingCodesToBufferOperation(MarkingCodeParams_12[] markingCodeParams): base(
            "addMarksToBuffer")
        {
            if (markingCodeParams?.Any() != true)
            {
                throw new ArgumentException(
                    string.Format(
                        ValidationStrings.ResourceManager.GetString("CollectionMinLengthError"),
                        GetType().GetProperty(nameof(Params)).GetPropertyDisplayName(), 1),
                    nameof(markingCodeParams));
            }

            if (markingCodeParams.Any(mcp => mcp.IsPositionMarkingCodeParams))
            {
                throw new ArgumentException(
                    ErrorStrings.ResourceManager.GetString("MarkingCodeCheckTypeError"));
            }

            Params = markingCodeParams;
        }

        /// <summary>
        /// Массив КМ для проверки
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// <item>Минимальное кол-во элементов: 1</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [ComplexObjectCollectionValidation(AllowNullItems = false, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "ComplexObjectCollectionValidationError")]
        [MinLength(1, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "CollectionMinLengthError")]
        [Display(Name = "Массив КМ для проверки")]
        public MarkingCodeParams_12[] Params { get; }
    }
}