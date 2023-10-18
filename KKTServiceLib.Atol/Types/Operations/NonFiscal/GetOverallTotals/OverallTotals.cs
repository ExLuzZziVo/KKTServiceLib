#region

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using KKTServiceLib.Atol.Types.Common.ReceiptsStat;

#endregion

namespace KKTServiceLib.Atol.Types.Operations.NonFiscal.GetOverallTotals
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