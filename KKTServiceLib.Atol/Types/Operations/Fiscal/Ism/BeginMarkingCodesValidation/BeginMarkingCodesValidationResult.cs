using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using KKTServiceLib.Atol.Types.Common.MarkingCodes;
using KKTServiceLib.Atol.Types.Operations.Fiscal.Ism.BeginMarkingCodeValidation;
using KKTServiceLib.Atol.Types.Operations.Fiscal.Ism.GetMarkingCodeValidationStatus;

namespace KKTServiceLib.Atol.Types.Operations.Fiscal.Ism.BeginMarkingCodesValidation
{
    [Description("Результат начала проверки элемента массива КМ")]
    public class BeginMarkingCodesValidationResult : GetMarkingCodeValidationStatusResult
    {
        /// <summary>
        /// Локальная проверка
        /// </summary>
        [Display(Name = "Локальная проверка")]
        public BeginMarkingCodeValidationResult OfflineValidation { get; set; }

        /// <summary>
        /// Результат сохранения КМ в таблице ФН-М в случае успешной проверки
        /// </summary>
        [Display(Name = "Результат сохранения КМ в таблице ФН-М в случае успешной проверки")]
        public ItemInfoCheckResult ItemInfoCheckResult { get; set; }
    }
}