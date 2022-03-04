using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using KKTServiceLib.Mercury.Types.Enums;

namespace KKTServiceLib.Mercury.Types.Common.MarkingCodes
{
    [Description("Результат проверки на сервере ИСМ")]
    public class MarkingCodeCheckOnlineValidationResult
    {
        /// <summary>
        /// Код завершения операции онлайн проверки КМ
        /// </summary>
        /// <remarks>
        /// При успешном завершении принимает значение <b>0</b>
        /// </remarks>
        [Display(Name = "Код завершения операции онлайн проверки КМ")]
        public int Result { get; set; }

        /// <summary>
        /// Описание ошибки, возникшей при онлайн проверке КМ
        /// </summary>
        [Display(Name = "Описание ошибки, возникшей при онлайн проверке КМ")]
        public string Description { get; set; }

        /// <summary>
        /// Код обработки запроса
        /// </summary>
        [Display(Name = "Код обработки запроса")]
        public MarkingCodeCheckResponseResult? ProcessingResult { get; set; }

        /// <summary>
        /// Результат проверки КП КМ положительный (true) или отрицательный
        /// </summary>
        [Display(Name = "Результат проверки КП КМ положительный (true) или отрицательный")]
        public bool? McCheckResult { get; set; }

        /// <summary>
        /// Сведения о статусе товара
        /// </summary>
        [Display(Name = "Сведения о статусе товара")]
        public MarkingCodeCheckItemStatusResult? PlannedStatusCheckResult { get; set; }

        /// <summary>
        /// Итоговый результат проверки КМ
        /// </summary>
        /// <remarks>
        /// Необработанное значение тега 2106, сформированного ФН по результатам проверки КМ в ФН и ИСМ
        /// </remarks>
        [Display(Name = "Итоговый результат проверки КМ")]
        public int? McCheckResultRaw { get; set; }

        /// <summary>
        /// Исправленная информация о коде маркировки
        /// </summary>
        [Display(Name = "Исправленная информация о коде маркировки")]
        public MarkingCodeCorrectedInfo CorrectedData { get; set; }
    }
}