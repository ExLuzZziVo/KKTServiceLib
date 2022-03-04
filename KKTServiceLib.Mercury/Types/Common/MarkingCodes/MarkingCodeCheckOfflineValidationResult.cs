using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using KKTServiceLib.Mercury.Types.Enums;

namespace KKTServiceLib.Mercury.Types.Common.MarkingCodes
{
    [Description("Результат проверки КМ в ФН")]
    public class MarkingCodeCheckOfflineValidationResult
    {
        /// <summary>
        /// Код результата проверки
        /// </summary>
        [Display(Name = "Код результата проверки")]
        public MarkingCodeCheckResult CheckResult { get; set; }

        /// <summary>
        /// Результат проверки
        /// </summary>
        [Display(Name = "Результат проверки")]
        public bool? IsValid { get; set; }
    }
}