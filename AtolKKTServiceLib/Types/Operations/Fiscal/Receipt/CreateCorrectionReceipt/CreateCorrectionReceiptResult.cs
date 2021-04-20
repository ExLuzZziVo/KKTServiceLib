#region

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using AtolKKTServiceLib.Types.Common.FiscalDocuments;
using AtolKKTServiceLib.Types.Common.Warnings;

#endregion

namespace AtolKKTServiceLib.Types.Operations.Fiscal.Receipt.CreateCorrectionReceipt
{
    [Description("Результат создания чека коррекции")]
    public class CreateCorrectionReceiptResult
    {
        /// <summary>
        /// Фискальные параметры чека
        /// </summary>
        [Display(Name = "Фискальные параметры чека")]
        public CorrectionReceiptFiscalDocumentParams FiscalParams { get; set; }

        /// <summary>
        /// Флаги предупреждений
        /// </summary>
        [Display(Name = "Флаги предупреждений")]
        public WarningFlags Warnings { get; set; }
    }
}