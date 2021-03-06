#region

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#endregion

namespace KKTServiceLib.Atol.Types.Operations.Fiscal.Shift.GetShiftTotals
{
    [Description("Подытоги по чекам")]
    public class PaymentsShiftTotals
    {
        /// <summary>
        /// Общая сумма чеков
        /// </summary>
        [Display(Name = "Общая сумма чеков")]
        public decimal Sum { get; set; }

        /// <summary>
        /// Подробно
        /// </summary>
        [Display(Name = "Подробно")]
        public PaymentsDetailsShiftTotals Payments { get; set; }
    }
}