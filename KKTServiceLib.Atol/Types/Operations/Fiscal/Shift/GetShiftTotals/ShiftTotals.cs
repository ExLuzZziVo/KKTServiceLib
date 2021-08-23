#region

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using KKTServiceLib.Atol.Types.Common.ReceiptsStat;

#endregion

namespace KKTServiceLib.Atol.Types.Operations.Fiscal.Shift.GetShiftTotals
{
    [Description("Сменные итоги")]
    public class ShiftTotals
    {
        /// <summary>
        /// Номер смены
        /// </summary>
        [Display(Name = "Номер смены")]
        public uint ShiftNumber { get; set; }

        /// <summary>
        /// Информация о денежном ящике
        /// </summary>
        [Display(Name = "Информация о денежном ящике")]
        public CashDrawerShiftTotals CashDrawer { get; set; }

        /// <summary>
        /// Итоги внесений
        /// </summary>
        [Display(Name = "Итоги внесений")]
        public MoneyOperationsShiftTotals Income { get; set; }

        /// <summary>
        /// Итоги выплат
        /// </summary>
        [Display(Name = "Итоги выплат")]
        public MoneyOperationsShiftTotals Outcome { get; set; }

        /// <summary>
        /// Итоги по чекам
        /// </summary>
        [Display(Name = "Итоги по чекам")]
        public ReceiptsStat Receipts { get; set; }
    }
}