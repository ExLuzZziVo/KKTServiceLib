using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using KKTServiceLib.Mercury.Types.Common.MarkingCodes;

namespace KKTServiceLib.Mercury.Types.Operations.Fiscal.Ism.GetMarkingCodeValidationStatus
{
    [Description("Результат получения результата проверки КМ")]
    public class GetMarkingCodeValidationStatusResult : OperationResult
    {
        /// <summary>
        /// Признак готовности результата проверки КМ
        /// </summary>
        [Display(Name = "Признак готовности результата проверки КМ")]
        public bool IsCompleted { get; set; }

        /// <summary>
        /// Результат проверки на сервере ИСМ
        /// </summary>
        [Display(Name = "Результат проверки на сервере ИСМ")]
        public MarkingCodeCheckOnlineValidationResult OnlineCheck { get; set; }
    }
}