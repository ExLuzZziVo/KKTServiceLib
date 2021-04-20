#region

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#endregion

namespace AtolKKTServiceLib.Types.Operations.Fiscal.Shift.GetShiftTotals
{
    [Description("Результат запроса сменных итогов")]
    public class GetShiftTotalsResult
    {
        /// <summary>
        /// Сменные итоги
        /// </summary>
        [Display(Name = "Сменные итоги")]
        public ShiftTotals ShiftTotals { get; set; }
    }
}