using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using KKTServiceLib.Atol.Types.Operations.Fiscal.CreateExchangeStatusReport;

namespace KKTServiceLib.Atol.Types.Common.FiscalDocuments
{
    [Description("Фискальный документ отчета о состоянии расчетов")]
    public class ExchangeStatusReportDocumentParams : FiscalDocumentParams
    {
        /// <summary>
        /// Счетчики количеств операций
        /// </summary>
        [Display(Name = "Счетчики количеств операций")]
        public FnQuantityCounters FnQuantityCounters { get; set; }

        /// <summary>
        /// Счетчики итогов операций
        /// </summary>
        [Display(Name = "Счетчики итогов операций")]
        public FnTotals FnTotals { get; set; }

        /// <summary>
        /// Счетчики итогов непереданных документов
        /// </summary>
        [Display(Name = "Счетчики итогов непереданных документов")]
        public FnUnsentDocsCounters FnUnsentDocsCounters { get; set; }

        /// <summary>
        /// Общее количество чеков
        /// </summary>
        [Display(Name = "Общее количество чеков")]
        public uint ReceiptsCount { get; set; }
    }
}