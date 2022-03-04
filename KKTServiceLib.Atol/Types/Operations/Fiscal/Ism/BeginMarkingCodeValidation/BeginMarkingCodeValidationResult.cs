using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using KKTServiceLib.Atol.Types.Common.MarkingCodes;

namespace KKTServiceLib.Atol.Types.Operations.Fiscal.Ism.BeginMarkingCodeValidation
{
    [Description("Результат начала проверки КМ")]
    public class BeginMarkingCodeValidationResult
    {
        /// <summary>
        /// Локальная проверка
        /// </summary>
        [Display(Name = "Локальная проверка")]
        public MarkingCodeCheckOfflineValidationResult OfflineValidation { get; set; }
    }
}