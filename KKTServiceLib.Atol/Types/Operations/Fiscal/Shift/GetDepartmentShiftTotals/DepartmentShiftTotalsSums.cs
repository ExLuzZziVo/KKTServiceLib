using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace KKTServiceLib.Atol.Types.Operations.Fiscal.Shift.GetDepartmentShiftTotals
{
    [Description("Суммы сменных итогов по секции")]
    public class DepartmentShiftTotalsSums
    {
        /// <summary>
        /// Сумма по чекам расхода
        /// </summary>
        [Display(Name = "Сумма по чекам расхода")]
        public decimal Buy { get; set; }
        
        /// <summary>
        /// Сумма по чекам возврата расхода
        /// </summary>
        [Display(Name = "Сумма по чекам возврата расхода")]
        public decimal BuyReturn { get; set; }
        
        /// <summary>
        /// Сумма по чекам прихода
        /// </summary>
        [Display(Name = "Сумма по чекам прихода")]
        public decimal Sell { get; set; }
        
        /// <summary>
        /// Сумма по чекам возврата прихода
        /// </summary>
        [Display(Name = "Сумма по чекам возврата прихода")]
        public decimal SellReturn { get; set; }
    }
}