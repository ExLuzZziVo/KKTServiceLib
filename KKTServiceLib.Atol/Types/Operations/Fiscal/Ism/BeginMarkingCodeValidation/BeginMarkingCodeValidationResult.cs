using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using KKTServiceLib.Atol.Types.Enums;

namespace KKTServiceLib.Atol.Types.Operations.Fiscal.Ism.BeginMarkingCodeValidation
{
    [Description("Результат начала проверки КМ")]
    public class BeginMarkingCodeValidationResult
    {
        /// <summary>
        /// Проверка КМ в ФН
        /// </summary>
        [Display(Name = "Проверка КМ в ФН")]
        public bool FmCheck { get; set; }

        /// <summary>
        /// Результат проверки
        /// </summary>
        [Display(Name = "Результат проверки")]
        public bool FmCheckResult { get; set; }

        /// <summary>
        /// Причина ошибки проверки
        /// </summary>
        [Display(Name = "Причина ошибки проверки")]
        public MarkingCodeCheckResult FmCheckErrorReason { get; set; }
    }
}