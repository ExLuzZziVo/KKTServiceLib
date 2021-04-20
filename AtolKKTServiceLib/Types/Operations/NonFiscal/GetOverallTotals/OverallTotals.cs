using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using AtolKKTServiceLib.Types.Common.ReceiptsStat;

namespace AtolKKTServiceLib.Types.Operations.NonFiscal.GetOverallTotals
{
    [Description("Необнуляемые итоги")]
    public class OverallTotals
    {
        /// <summary>
        /// Итоги по чекам
        /// </summary>
        [Display(Name = "Итоги по чекам")]
        public ReceiptsStat Receipts { get; set; }
    }
}