#region

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#endregion

namespace AtolKKTServiceLib.Types.Common.FiscalDocuments
{
    [Description("Фискальный документ чека коррекции")]
    public class CorrectionReceiptFiscalDocumentParams : FiscalDocumentParams
    {
        /// <summary>
        /// Итог
        /// </summary>
        [Display(Name = "Итог")]
        public decimal Total { get; set; }
    }
}