using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace KKTServiceLib.Atol.Types.Operations.Fiscal.Shift.GetDepartmentShiftTotals
{
    [Description("Результат запроса сменных итогов по секциям")]
    public class GetDepartmentShiftTotalsResult
    {
        /// <summary>
        /// Сменные итоги по секциям
        /// </summary>
        [Display(Name = "Сменные итоги по секциям")]
        public DepartmentShiftTotals DepartmentSum { get; set; }
    }
}