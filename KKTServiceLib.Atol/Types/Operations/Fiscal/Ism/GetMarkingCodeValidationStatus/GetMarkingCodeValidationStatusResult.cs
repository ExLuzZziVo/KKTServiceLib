using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using KKTServiceLib.Atol.Types.Common.MarkingCodes;

namespace KKTServiceLib.Atol.Types.Operations.Fiscal.Ism.GetMarkingCodeValidationStatus
{
    [Description("Результат получения результата проверки КМ")]
    public class GetMarkingCodeValidationStatusResult
    {
        /// <summary>
        /// Признак готовности результата проверки КМ
        /// </summary>
        [Display(Name = "Признак готовности результата проверки КМ")]
        public bool Ready { get; set; }

        /// <summary>
        /// Признак отправки запроса о проверке КМ
        /// </summary>
        [Display(Name = "Признак отправки запроса о проверке КМ")]
        public bool SentImcRequest { get; set; }

        /// <summary>
        /// Ошибка драйвера
        /// </summary>
        [Display(Name = "Ошибка драйвера")]
        public MarkingCodeCheckDriverError DriverError { get; set; }

        /// <summary>
        /// Проверка на сервере ИСМ
        /// </summary>
        [Display(Name = "Проверка на сервере ИСМ")]
        public MarkingCodeCheckOnlineValidationResult OnlineValidation { get; set; }
    }
}