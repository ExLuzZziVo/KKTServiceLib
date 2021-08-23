#region

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using KKTServiceLib.Atol.Types.Common.Exchange;
using KKTServiceLib.Atol.Types.Common.FiscalDocuments;
using KKTServiceLib.Atol.Types.Common.Warnings;

#endregion

namespace KKTServiceLib.Atol.Types.Operations.Fiscal.CreateExchangeStatusReport
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