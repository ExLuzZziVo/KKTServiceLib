#region

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#endregion

namespace AtolKKTServiceLib.Types.Common.FiscalDocuments
{
    [Description("Фискальный документ чека")]
    public class ReceiptFiscalDocumentParams : FiscalDocumentParams
    {
        /// <summary>
        /// Итог
        /// </summary>
        [Display(Name = "Итог")]
        public decimal Total { get; set; }

        /// <summary>
        /// Номер чека в смене
        /// </summary>
        [Display(Name = "Номер чека в смене")]
        public uint FiscalReceiptNumber { get; set; }
    }
}