using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using KKTServiceLib.Atol.Types.Enums;

namespace KKTServiceLib.Atol.Types.Common.MarkingCodes
{
    [Description("Результат проверки КМ в ФН")]
    public class MarkingCodeCheckOfflineValidationResult
    {
        /// <summary>
        /// Проверка КМ в ФН
        /// </summary>
        [Display(Name = "Проверка КМ в ФН")]
        public bool FmCheck { get; set; }

        /// <summary>
        /// Результат проверки
        /// </summary>
        [Display(Name = "Результат проверки КМ в ФН")]
        public bool FmCheckResult { get; set; }

        /// <summary>
        /// Код результата проверки
        /// </summary>
        [Display(Name = "Код результата проверки")]
        public MarkingCodeCheckResult FmCheckErrorReason { get; set; }
    }
}