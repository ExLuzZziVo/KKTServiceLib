#region

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using KKTServiceLib.Atol.Types.Operations.Fiscal.Shift.GetShiftTotals;

#endregion

namespace KKTServiceLib.Atol.Types.Common.ReceiptsStat
{
    [Description("Итоги по чекам")]
    public class ReceiptsStat
    {
        /// <summary>
        /// Приход
        /// </summary>
        [Display(Name = "Приход")]
        public PaymentsShiftTotals Sell { get; set; }

        /// <summary>
        /// Возврат прихода
        /// </summary>
        [Display(Name = "Возврат прихода")]
        public PaymentsShiftTotals SellReturn { get; set; }

        /// <summary>
        /// Расход
        /// </summary>
        [Display(Name = "Расход")]
        public PaymentsShiftTotals Buy { get; set; }

        /// <summary>
        /// Возврат расхода
        /// </summary>
        [Display(Name = "Возврат расхода")]
        public PaymentsShiftTotals BuyReturn { get; set; }
    }
}