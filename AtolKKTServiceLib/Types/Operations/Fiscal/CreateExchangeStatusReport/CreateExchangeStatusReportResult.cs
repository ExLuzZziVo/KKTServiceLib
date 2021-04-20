#region

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using AtolKKTServiceLib.Types.Common.Exchange;
using AtolKKTServiceLib.Types.Common.FiscalDocuments;
using AtolKKTServiceLib.Types.Common.Warnings;

#endregion

namespace AtolKKTServiceLib.Types.Operations.Fiscal.CreateExchangeStatusReport
{
    [Description("Результат создания отчета о состоянии расчетов")]
    public class CreateExchangeStatusReportResult
    {
        /// <summary>
        /// Фискальные параметры отчета
        /// </summary>
        [Display(Name = "Фискальные параметры отчета")]
        public FiscalDocumentParams FiscalParams { get; set; }

        /// <summary>
        /// Флаги предупреждений
        /// </summary>
        [Display(Name = "Флаги предупреждений")]
        public WarningFlags Warnings { get; set; }

        /// <summary>
        /// Состояние
        /// </summary>
        [Display(Name = "Состояние")]
        public ExchangeStatus Status { get; set; }

        /// <summary>
        /// Ошибки обмена
        /// </summary>
        [Display(Name = "Ошибки обмена")]
        public ExchangeErrorStatus Errors { get; set; }
    }
}