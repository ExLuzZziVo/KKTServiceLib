#region

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#endregion

namespace AtolKKTServiceLib.Types.Operations.Fiscal.Shift.GetShiftTotals
{
    [Description("Итоги внесений/выплат")]
    public class MoneyOperationsShiftTotals
    {
        /// <summary>
        /// Количество операций
        /// </summary>
        [Display(Name = "Количество операций")]
        public uint Count { get; set; }

        /// <summary>
        /// Сумма операций
        /// </summary>
        [Display(Name = "Сумма операций")]
        public decimal Sum { get; set; }
    }
}