using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using KKTServiceLib.Atol.Types.Common.MarkingCodes;
using KKTServiceLib.Shared.Helpers;
using KKTServiceLib.Shared.Resources;
using KKTServiceLib.Shared.Types.ValidationAttributes;

namespace KKTServiceLib.Atol.Types.Operations.Fiscal.Ism.ForceAddMarkingCodesToBuffer
{
    [Description("Принудительное добавление массива КМ в таблицу проверенных КМ")]
    public class ForceAddMarkingCodesToBufferOperation : Operation<ForceAddMarkingCodesToBufferResult[]>
    {
        /// <summary>
        /// Принудительное добавление массива КМ в таблицу проверенных КМ
        /// </summary>
        /// <param name="markingCodeParams">Массив КМ для проверки</param>
        public ForceAddMarkingCodesToBufferOperation(MarkingCodeParams_12[] markingCodeParams) : base(
            "addMarksToBuffer")
        {
            if (markingCodeParams?.Any() != true)
            {
                throw new ArgumentException(
                    string.Format(
                        ErrorStrings.ResourceManager.GetString("MinLengthError"),
                        GetType().GetProperty(nameof(Params)).GetDisplayName(), 1),
                    nameof(markingCodeParams));
            }

            if (markingCodeParams.Any(mcp => mcp.IsPositionMarkingCodeParams))
            {
                throw new ArgumentException(
                    Resources.ErrorStrings.ResourceManager.GetString("MarkingCodeCheckTypeError"));
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
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        [ComplexObjectCollectionValidation(AllowNullItems = false, ErrorMessageResourceType = typeof(ErrorStrings),
            ErrorMessageResourceName = "ComplexObjectCollectionValidationError")]
        [MinLength(1, ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "MinLengthError")]
        [Display(Name = "Массив КМ для проверки")]
        public MarkingCodeParams_12[] Params { get; }
    }
}