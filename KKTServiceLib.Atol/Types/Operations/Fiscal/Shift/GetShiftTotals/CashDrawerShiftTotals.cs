#region

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#endregion

namespace KKTServiceLib.Atol.Types.Operations.Fiscal.Shift.GetShiftTotals
{
    [Description("Информация о денежном ящике")]
    public class CashDrawerShiftTotals
    {
        /// <summary>
        /// Сумма наличных в денежном ящике
        /// </summary>
        [Display(Name = "Сумма наличных в денежном ящике")]
        public decimal Sum { get; set; }
    }
}